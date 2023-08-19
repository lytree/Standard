using StackExchange.Redis;
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
			await foreach (var key in server.KeysAsync(pattern: pattern))
			{
				keyNum += Del(key!);
			}
		}

		return keyNum;
	}

	public bool Exists(string key)
	{
		return _connection.GetDatabase().KeyExists(key);
	}

	public Task<bool> ExistsAsync(string key)
	{
		return _connection.GetDatabase().KeyExistsAsync(key);
	}

	public string? Get(string key) => _connection.GetDatabase().StringGet(key);

	public T? Get<T>(string key)
	{
		return JsonHelper.Deserialize<T>(_connection.GetDatabase().StringGet(key));
	}

	public async Task<string?> GetAsync(string key)
	{
		return await _connection.GetDatabase().StringGetAsync(key);
	}

	public async Task<T?> GetAsync<T>(string key)
	{
		return JsonHelper.Deserialize<T>(await _connection.GetDatabase().StringGetAsync(key));
	}

	public void Set(string key, object value)
	{
		_connection.GetDatabase().SetAdd(key, JsonHelper.Serialize(value));
	}

	public void Set(string key, object value, TimeSpan expire)
	{
		_connection.GetDatabase().SetAdd(key, JsonHelper.Serialize(value));
		_connection.GetDatabase().KeyExpire(key, expire);
	}

	public async Task SetAsync(string key, object value, TimeSpan? expire = null)
	{
		await _connection.GetDatabase().SetAddAsync(key, JsonHelper.Serialize(value));
		if (expire != null)
		{
			await _connection.GetDatabase().KeyExpireAsync(key, expire);
		}

	}

	public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> func, TimeSpan? expire = null)
	{
		if (await ExistsAsync(key))
		{
			try
			{
				return await GetAsync<T>(key);
			}
			catch
			{
				await DelAsync(key);
			}
		}

		var result = await func.Invoke();

		await SetAsync(key, result,expire);

		return result;
	}
}