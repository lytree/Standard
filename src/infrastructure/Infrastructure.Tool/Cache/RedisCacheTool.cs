﻿using StackExchange.Redis;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Infrastructure.Tool.Cache;

/// <summary>
/// Redis缓存
/// </summary>
public partial class RedisCacheTool : ICacheTool
{
	private static readonly Regex PatternRegex = new("\\{.*\\}");

	private readonly ConnectionMultiplexer _connection;
	public RedisCacheTool(ConnectionMultiplexer connection)
	{
		_connection = connection;
	}
	public long Del(params string[] keys)
	{
		foreach (string key in keys)
		{
			_connection.GetDatabase().KeyDelete(key);
		}
		return keys.Length;
	}

	public Task<long> DelAsync(params string[] keys)
	{
		foreach (string key in keys)
		{
			_connection.GetDatabase().KeyDeleteAsync(key);
		}
		return Task.FromResult(Convert.ToInt64(keys.Length));
	}

	public async Task<long> DelByPatternAsync(string pattern)
	{
		if (pattern == null)
			return default;

		pattern = PatternRegex.Replace(pattern, "*");
		var servers = _connection.GetServers();
		long keyNum = default;
		foreach (var server in servers)
		{
			var keys = server.Keys(pattern: pattern);
			keyNum += keys.LongCount();
		}

		return keyNum;
	}

	public bool Exists(string key)
	{
		return _redisClient.Exists(key);
	}

	public Task<bool> ExistsAsync(string key)
	{
		return _redisClient.ExistsAsync(key);
	}

	public string Get(string key)
	{
		return _redisClient.Get(key);
	}

	public T Get<T>(string key)
	{
		return _redisClient.Get<T>(key);
	}

	public Task<string> GetAsync(string key)
	{
		return _redisClient.GetAsync(key);
	}

	public Task<T> GetAsync<T>(string key)
	{
		return _redisClient.GetAsync<T>(key);
	}

	public void Set(string key, object value)
	{
		_redisClient.Set(key, value);
	}

	public void Set(string key, object value, TimeSpan expire)
	{
		_redisClient.Set(key, value, expire);
	}

	public Task SetAsync(string key, object value, TimeSpan? expire = null)
	{
		return _redisClient.SetAsync(key, value, expire.HasValue ? expire.Value.TotalSeconds.ToInt() : 0);
	}

	public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> func, TimeSpan? expire = null)
	{
		if (await _redisClient.ExistsAsync(key))
		{
			try
			{
				return await _redisClient.GetAsync<T>(key);
			}
			catch
			{
				await _redisClient.DelAsync(key);
			}
		}

		var result = await func.Invoke();

		await _redisClient.SetAsync(key, result, expire.HasValue ? expire.Value.TotalSeconds.ToInt() : 0);

		return result;
	}
}