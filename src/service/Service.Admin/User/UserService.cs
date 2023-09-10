using Microsoft.AspNetCore.Mvc;
using System.Data;
using FreeSql;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using Service.Admin.User.Dto;
using Service.Admin.Auth.Dto;
using Plugin.DynamicApi.Attributes;
using Plugin.DynamicApi;
using Infrastructure.Service;
using Infrastructure;
using Repository.Admin.Repository.User;
using Repository.Admin.Repository.UserRole;
using Repository.Admin.Repository.RolePermission;
using Repository.Admin.Repository.Api;
using Repository.Admin.Repository.PermissionApi;
using Repository.Admin.Repository.Role;

namespace Service.Admin.User;

/// <summary>
/// 用户服务
/// </summary>
[Order(10)]
[DynamicApi(Area = AdminConsts.AreaName)]
public partial class UserService : BaseService, IUserService, IDynamicApi
{
    private IUserRepository _userRepository => LazyGetRequiredService<IUserRepository>();
    private IApiRepository _apiRepository => LazyGetRequiredService<IApiRepository>();
    private IUserRoleRepository _userRoleRepository => LazyGetRequiredService<IUserRoleRepository>();
    private IPasswordHasher<UserEntity> _passwordHasher => LazyGetRequiredService<IPasswordHasher<UserEntity>>();

    public UserService()
    {
    }

    /// <summary>
    /// 查询用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UserGetOutput> GetAsync(long id)
    {
        var userEntity = await _userRepository.Select
        .WhereDynamic(id)
        .IncludeMany(a => a.Roles.Select(b => new RoleEntity { Id = b.Id, Name = b.Name }))
        .ToOneAsync(a => new
        {
            a.Id,
            a.UserName,
            a.Name,
            a.Mobile,
            a.Email,
            a.Roles,
            a.ManagerUserId,
            ManagerUserName = a.ManagerUser.Name,
        });

        var output = Mapper.Map<UserGetOutput>(userEntity);

        return output;
    }

    /// <summary>
    /// 查询分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<PageOutput<UserGetPageOutput>> GetPageAsync(PageInput<UserGetPageDto> input)
    {

        var list = await _userRepository.Select
        .WhereDynamicFilter(input.DynamicFilter)
        .Count(out var total)
        .OrderByDescending(true, a => a.Id)
        .IncludeMany(a => a.Roles.Select(b => new RoleEntity { Name = b.Name }))
        .Page(input.CurrentPage, input.PageSize)
        .ToListAsync(a => new UserGetPageOutput { Roles = a.Roles });


        var data = new PageOutput<UserGetPageOutput>()
        {
            List = Mapper.Map<List<UserGetPageOutput>>(list),
            Total = total
        };

        return data;
    }

    /// <summary>
    /// 查询登录用户信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [NonAction]
    public async Task<AuthLoginOutput> GetLoginUserAsync(long id)
    {
        var output = await _userRepository.Select
            .WhereDynamic(id).ToOneAsync<AuthLoginOutput>();


        return output;
    }



    /// <summary>
    /// 查询用户基本信息
    /// </summary>
    /// <returns></returns>
    [Login]
    public async Task<UserGetBasicOutput> GetBasicAsync()
    {
        if (!(User?.Id > 0))
        {
            throw ResultOutput.Exception("未登录！");
        }

        var data = await _userRepository.GetAsync<UserGetBasicOutput>(User.Id);
        data.Mobile = DataMaskHelper.PhoneMask(data.Mobile);
        data.Email = DataMaskHelper.EmailMask(data.Email);
        return data;
    }

    /// <summary>
    /// 查询用户权限信息
    /// </summary>
    /// <returns></returns>
    public async Task<IList<UserPermissionsOutput>> GetPermissionsAsync()
    {
        var key = CacheKeys.UserPermissions + User.Id;
        var result = await Cache.GetOrSetAsync(key, async () =>
        {

            return await _apiRepository
            .Where(a => _apiRepository.Orm.Select<UserRoleEntity, RolePermissionEntity, PermissionApiEntity>()
            .InnerJoin((b, c, d) => b.RoleId == c.RoleId && b.UserId == User.Id)
            .InnerJoin((b, c, d) => c.PermissionId == d.PermissionId)
            .Where((b, c, d) => d.ApiId == a.Id).Any())
            .ToListAsync<UserPermissionsOutput>();
        });
        return result;
    }

    /// <summary>
    /// 新增用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [AdminTransaction]
    public virtual async Task<long> AddAsync(UserAddInput input)
    {
        Expression<Func<UserEntity, bool>> where = a => a.UserName == input.UserName;
        where = where.Or(input.Mobile != null, a => a.Mobile == input.Mobile)
            .Or(input.Email != null, a => a.Email == input.Email);

        var existsUser = await _userRepository.Select.Where(where)
            .FirstAsync(a => new { a.UserName, a.Mobile, a.Email });

        if (existsUser != null)
        {
            if (existsUser.UserName == input.UserName)
            {
                throw ResultOutput.Exception($"账号已存在");
            }

            if (input.Mobile != null && existsUser.Mobile == input.Mobile)
            {
                throw ResultOutput.Exception($"手机号已存在");
            }

            if (input.Email != null && existsUser.Email == input.Email)
            {
                throw ResultOutput.Exception($"邮箱已存在");
            }
        }

        // 用户信息
        if (input.Password == null)
        {
            input.Password = "12345678";
        }

        var entity = Mapper.Map<UserEntity>(input);
        entity.Type = UserType.DefaultUser;
        //if (_appConfig.PasswordHasher)
        //{
        //	entity.Password = _passwordHasher.HashPassword(entity, input.Password);
        //	entity.PasswordEncryptType = PasswordEncryptType.PasswordHasher;
        //}
        //else
        //{
        entity.Password = MD5Encrypt.Encrypt32(input.Password);
        entity.PasswordEncryptType = PasswordEncryptType.MD5Encrypt32;
        //}
        var user = await _userRepository.InsertAsync(entity);
        var userId = user.Id;

        //用户角色
        if (input.RoleIds != null && input.RoleIds.Any())
        {
            var roles = input.RoleIds.Select(roleId => new UserRoleEntity
            {
                UserId = userId,
                RoleId = roleId
            }).ToList();
            await _userRoleRepository.InsertAsync(roles);
        }



        return userId;
    }

    /// <summary>
    /// 修改用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [AdminTransaction]
    public virtual async Task UpdateAsync(UserUpdateInput input)
    {

        Expression<Func<UserEntity, bool>> where = a => a.UserName == input.UserName;
        where = where.Or(input.Mobile != null, a => a.Mobile == input.Mobile)
            .Or(input.Email != null, a => a.Email == input.Email);

        var existsUser = await _userRepository.Select.Where(a => a.Id != input.Id).Where(where)
            .FirstAsync(a => new { a.UserName, a.Mobile, a.Email });

        if (existsUser != null)
        {
            if (existsUser.UserName == input.UserName)
            {
                throw ResultOutput.Exception($"账号已存在");
            }

            if (input.Mobile != null && existsUser.Mobile == input.Mobile)
            {
                throw ResultOutput.Exception($"手机号已存在");
            }

            if (input.Email != null && existsUser.Email == input.Email)
            {
                throw ResultOutput.Exception($"邮箱已存在");
            }
        }

        var user = await _userRepository.GetAsync(input.Id);
        if (!(user?.Id > 0))
        {
            throw ResultOutput.Exception("用户不存在");
        }

        Mapper.Map(input, user);
        await _userRepository.UpdateAsync(user);

        var userId = user.Id;

        // 用户角色
        await _userRoleRepository.DeleteAsync(a => a.UserId == userId);
        if (input.RoleIds != null && input.RoleIds.Any())
        {
            var roles = input.RoleIds.Select(roleId => new UserRoleEntity
            {
                UserId = userId,
                RoleId = roleId
            }).ToList();
            await _userRoleRepository.InsertAsync(roles);
        }


        await Cache.DelAsync(CacheKeys.DataPermission + user.Id);
    }

    /// <summary>
    /// 更新用户基本信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [Login]
    public async Task UpdateBasicAsync(UserUpdateBasicInput input)
    {
        var entity = await _userRepository.GetAsync(User.Id);
        entity = Mapper.Map(input, entity);
        await _userRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 修改用户密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [Login]
    public async Task ChangePasswordAsync(UserChangePasswordInput input)
    {
        if (input.ConfirmPassword != input.NewPassword)
        {
            throw ResultOutput.Exception("新密码和确认密码不一致");
        }

        var entity = await _userRepository.GetAsync(User.Id);
        var oldPassword = MD5Encrypt.Encrypt32(input.OldPassword);
        if (oldPassword != entity.Password)
        {
            throw ResultOutput.Exception("旧密码不正确");
        }

        entity.Password = MD5Encrypt.Encrypt32(input.NewPassword);
        await _userRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<string> ResetPasswordAsync(UserResetPasswordInput input)
    {
        var entity = await _userRepository.GetAsync(input.Id);
        var password = input.Password;
        if (password == null)
        {
            password = "111111";
        }
        //if (_appConfig.PasswordHasher)
        //{
        //    entity.Password = _passwordHasher.HashPassword(entity, password);
        //    entity.PasswordEncryptType = PasswordEncryptType.PasswordHasher;
        //}
        //else
        //{
        entity.Password = MD5Encrypt.Encrypt32(password);
        entity.PasswordEncryptType = PasswordEncryptType.MD5Encrypt32;
        //}
        await _userRepository.UpdateAsync(entity);
        return password;
    }


    /// <summary>
    /// 彻底删除用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [AdminTransaction]
    public virtual async Task DeleteAsync(long id)
    {
        var user = await _userRepository.Select.WhereDynamic(id).ToOneAsync(a => new { a.Type });
        if (user == null)
        {
            throw ResultOutput.Exception("用户不存在");
        }

        if (user.Type == UserType.PlatformAdmin)
        {
            throw ResultOutput.Exception($"平台管理员禁止删除");
        }



        //删除用户角色
        await _userRoleRepository.DeleteAsync(a => a.UserId == id);

        //删除用户
        await _userRepository.DeleteAsync(a => a.Id == id);

        //删除用户数据权限缓存
        await Cache.DelAsync(CacheKeys.DataPermission + id);
    }

    /// <summary>
    /// 批量彻底删除用户
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [AdminTransaction]
    public virtual async Task BatchDeleteAsync(long[] ids)
    {
        var admin = await _userRepository.Select.Where(a => ids.Contains(a.Id) &&
        (a.Type == UserType.PlatformAdmin)).AnyAsync();

        if (admin)
        {
            throw ResultOutput.Exception("平台管理员禁止删除");
        }

        //删除用户角色
        await _userRoleRepository.DeleteAsync(a => ids.Contains(a.UserId));
        //删除用户
        await _userRepository.DeleteAsync(a => ids.Contains(a.Id));

        foreach (var userId in ids)
        {
            await Cache.DelAsync(CacheKeys.DataPermission + userId);
        }
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [AdminTransaction]
    public virtual async Task SoftDeleteAsync(long id)
    {
        var user = await _userRepository.Select.WhereDynamic(id).ToOneAsync(a => new { a.Type });
        if (user == null)
        {
            throw ResultOutput.Exception("用户不存在");
        }

        if (user.Type == UserType.PlatformAdmin)
        {
            throw ResultOutput.Exception("平台管理员禁止删除");
        }

        await _userRoleRepository.DeleteAsync(a => a.UserId == id);
        await _userRepository.SoftDeleteAsync(id);

        await Cache.DelAsync(CacheKeys.DataPermission + id);
    }

    /// <summary>
    /// 批量删除用户
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [AdminTransaction]
    public virtual async Task BatchSoftDeleteAsync(long[] ids)
    {
        var admin = await _userRepository.Select.Where(a => ids.Contains(a.Id) &&
        (a.Type == UserType.PlatformAdmin)).AnyAsync();

        if (admin)
        {
            throw ResultOutput.Exception("平台管理员禁止删除");
        }

        await _userRoleRepository.DeleteAsync(a => ids.Contains(a.UserId));

        await _userRepository.SoftDeleteAsync(ids);

        foreach (var userId in ids)
        {
            await Cache.DelAsync(CacheKeys.DataPermission + userId);
        }
    }

}