using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

internal static class StringExtension
{
	/// <summary>
	/// 判断字符串是否为Null、空
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool IsNull(this string s)
	{
		return string.IsNullOrWhiteSpace(s);
	}

	/// <summary>
	/// 判断字符串是否不为Null、空
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool NotNull(this string s)
	{
		return !string.IsNullOrWhiteSpace(s);
	}

	/// <summary>
	/// 与字符串进行比较，忽略大小写
	/// </summary>
	/// <param name="s"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public static bool EqualsIgnoreCase(this string s, string value)
	{
		return s.Equals(value, StringComparison.OrdinalIgnoreCase);
	}

	/// <summary>
	/// 首字母转小写
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static string FirstCharToLower(this string s)
	{
		if (string.IsNullOrEmpty(s))
			return s;

		string str = s.First().ToString().ToLower() + s.Substring(1);
		return str;
	}

	/// <summary>
	/// 首字母转大写
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static string FirstCharToUpper(this string s)
	{
		if (string.IsNullOrEmpty(s))
			return s;

		string str = s.First().ToString().ToUpper() + s.Substring(1);
		return str;
	}


	public static string ToPath(this string s)
	{
		if (s.IsNull())
			return string.Empty;

		return s.Replace(@"\", "/");
	}

	public static string Format(this string str, object obj)
	{
		if (str.IsNull())
		{
			return str;
		}
		string s = str;
		if (obj.GetType().Name == "JObject")
		{
			foreach (var item in (JsonObject)obj)
			{
				var k = item.Key.ToString();
				var v = item.Value.ToString();
				s = Regex.Replace(s, "\\{" + k + "\\}", v, RegexOptions.IgnoreCase);
			}
		}
		else
		{
			foreach (System.Reflection.PropertyInfo p in obj.GetType().GetProperties())
			{
				var xx = p.Name;
				var yy = p.GetValue(obj).ToString();
				s = Regex.Replace(s, "\\{" + xx + "\\}", yy, RegexOptions.IgnoreCase);
			}
		}
		return s;
	}
}
