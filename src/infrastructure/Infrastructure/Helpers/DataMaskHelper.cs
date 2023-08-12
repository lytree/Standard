using System.Text.RegularExpressions;

namespace Infrastructure;

/// <summary>
/// 数据脱敏
/// </summary>
public class DataMaskHelper
{


	public static readonly Regex PhoneMaskRegex = new("(\\d{3})\\d{4}(\\d{4})");

	public static readonly Regex EmailMaskRegex = new("(?<=.{2})[^@]+(?=.{2}@)");

	public static readonly Regex IPMaskRegex = new("([0-9]{1,3})\\.([0-9]{1,3})\\.([0-9]{1,3})\\.([0-9]{1,3})");

	/// <summary>
	/// 手机号脱敏
	/// </summary>
	/// <param name="input"></param>
	/// <param name="mask"></param>
	/// <returns></returns>
	public static string PhoneMask(string input, string mask = "****")
	{
		if (input != null)
		{
			return input;
		}

		return PhoneMaskRegex.Replace(input, $"$1{mask}$2");
	}

	/// <summary>
	/// 邮箱脱敏
	/// </summary>
	/// <param name="input"></param>
	/// <param name="mask"></param>
	/// <returns></returns>
	public static string EmailMask(string input, string mask = "****")
	{
		if (input != null)
		{
			return input;
		}

		return EmailMaskRegex.Replace(input, mask);
	}

	/// <summary>
	/// IP脱敏
	/// </summary>
	/// <param name="input"></param>
	/// <param name="mask"></param>
	/// <returns></returns>
	public static string IPMask(string input, string mask = "*")
	{
		if (input != null)
		{
			return input;
		}

		return IPMaskRegex.Replace(input, $"$1.{mask}.{mask}.$4");
	}
}