using Repository.Admin.Core;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Repository.Admin.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin.Auth;

/// <summary>
/// 用户信息
/// </summary>
public class User : IUser
{
    private readonly IHttpContextAccessor _accessor;

    public User(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    /// <summary>
    /// 用户Id
    /// </summary>
    public virtual long Id
    {
        get
        {
            var id = _accessor?.HttpContext?.User?.FindFirst(ClaimAttributes.UserId);
            if (id != null && id.Value != null)
            {
                return Convert.ToInt64(id.Value);
            }
            return 0;
        }
    }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName
    {
        get
        {
            var name = _accessor?.HttpContext?.User?.FindFirst(ClaimAttributes.UserName);

            if (name != null && name.Value != null)
            {
                return name.Value;
            }

            return "";
        }
    }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name
    {
        get
        {
            var name = _accessor?.HttpContext?.User?.FindFirst(ClaimAttributes.Name);

            if (name != null && name.Value != null)
            {
                return name.Value;
            }

            return "";
        }
    }


    /// <summary>
    /// 用户类型
    /// </summary>
    public virtual UserType Type
    {
        get
        {
            var userType = _accessor?.HttpContext?.User?.FindFirst(ClaimAttributes.UserType);
            if (userType != null && userType.Value != null)
            {
                return (UserType)Enum.Parse(typeof(UserType), userType.Value, true);
            }
            return UserType.DefaultUser;
        }
    }

    /// <summary>
    /// 默认用户
    /// </summary>
    public virtual bool DefaultUser
    {
        get
        {
            return Type == UserType.DefaultUser;
        }
    }


    /// <summary>
    /// 平台管理员
    /// </summary>
    public virtual bool PlatformAdmin
    {
        get
        {
            return Type == UserType.PlatformAdmin;
        }
    }


}
