using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Repository.Admin.Core;

public interface IUserToken
{
	string Create(Claim[] claims);

	JwtSecurityToken Decode(string jwtToken);
}