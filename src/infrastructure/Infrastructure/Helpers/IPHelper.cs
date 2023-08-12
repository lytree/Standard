
using System.Linq;
using System.Text.RegularExpressions;

namespace Infrastructure;

public class IPHelper
{
	/// <summary>
	/// 是否为ip
	/// </summary>
	/// <param name="ip"></param>
	/// <returns></returns>
	public static bool IsIP(string ip)
	{
		return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
	}


}