using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Admin.Auth.Dto;
using System.Threading.Tasks;

namespace Service.Admin.Auth;

/// <summary>
/// 认证授权接口
/// </summary>
public interface IAuthService
{
	string GetToken(AuthLoginOutput user);

	Task<dynamic> LoginAsync(AuthLoginInput input);

	Task<AuthGetUserInfoOutput> GetUserInfoAsync();

	Task<AuthGetPasswordEncryptKeyOutput> GetPasswordEncryptKeyAsync();

	Task<dynamic> Refresh([BindRequired] string token);

}