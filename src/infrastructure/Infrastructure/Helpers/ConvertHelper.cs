﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public static class ConvertHelper
{
	/// <summary>
	/// 转换为16进制
	/// </summary>
	/// <param name="bytes"></param>
	/// <param name="lowerCase">是否小写</param>
	/// <returns></returns>
	public static string ToHex(byte[] bytes, bool lowerCase = true)
	{
		if (bytes == null)
			return null;

		var result = new StringBuilder();
		var format = lowerCase ? "x2" : "X2";
		for (var i = 0; i < bytes.Length; i++)
		{
			result.Append(bytes[i].ToString(format));
		}

		return result.ToString();
	}
	/// <summary>
	/// 16进制转字节数组
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static byte[] HexToBytes(string s)
	{
		if (s == null)
			return null;
		var bytes = new byte[s.Length / 2];

		for (int x = 0; x < s.Length / 2; x++)
		{
			int i = (Convert.ToInt32(s.Substring(x * 2, 2), 16));
			bytes[x] = (byte)i;
		}

		return bytes;
	}
	/// <summary>
	/// 转换为Base64
	/// </summary>
	/// <param name="bytes"></param>
	/// <returns></returns>
	public static string ToBase64(byte[] bytes)
	{
		if (bytes == null)
			return null;

		return Convert.ToBase64String(bytes);
	}
}
