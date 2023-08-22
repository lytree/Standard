using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Admin.Auth.Dto;
using Service.Admin.User.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Admin.User;

/// <summary>
/// 用户接口
/// </summary>
public interface IUserService
{
	Task<UserGetOutput> GetAsync(long id);

	Task<PageOutput<UserGetPageOutput>> GetPageAsync(PageInput<UserGetPageDto> input);

	Task<AuthLoginOutput> GetLoginUserAsync(long id);

	Task<long> AddAsync(UserAddInput input);

	Task<long> AddMemberAsync(UserAddMemberInput input);

	Task UpdateAsync(UserUpdateInput input);

	Task DeleteAsync(long id);

	Task BatchDeleteAsync(long[] ids);

	Task SoftDeleteAsync(long id);

	Task BatchSoftDeleteAsync(long[] ids);

	Task ChangePasswordAsync(UserChangePasswordInput input);

	Task<string> ResetPasswordAsync(UserResetPasswordInput input);

	Task UpdateBasicAsync(UserUpdateBasicInput input);

	Task<UserGetBasicOutput> GetBasicAsync();

	Task<IList<UserPermissionsOutput>> GetPermissionsAsync();

}