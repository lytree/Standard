﻿
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure;

/// <summary>
/// Json帮助类
/// </summary>
public class JsonHelper
{
	private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
	};

	/// <summary>
	/// 序列化
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="obj"></param>
	/// <returns></returns>
	public static string Serialize<T>(T obj)
	{
		return JsonSerializer.Serialize(obj, typeof(T), _jsonSerializerOptions);
	}

	/// <summary>
	/// 反序列化
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="json"></param>
	/// <returns></returns>
	public static T Deserialize<T>(string json)
	{
		return JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);
	}

	/// <summary>
	/// 反序列化
	/// </summary>
	/// <param name="json">json文本</param>
	/// <param name="type">类型</param>
	/// <returns></returns>
	public static object Deserialize(string json, Type type)
	{
		return JsonSerializer.Deserialize(json, type, _jsonSerializerOptions);
	}
}