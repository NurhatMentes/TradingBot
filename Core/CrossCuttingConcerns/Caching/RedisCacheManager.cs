using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Core.CrossCuttingConcerns.Caching;
public class RedisCacheManager : ICacheManager
{
    private readonly IConnectionMultiplexer _redisConnection;
    private readonly IDatabase _cache;

    public RedisCacheManager(IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("Redis:ConnectionString");
        _redisConnection = ConnectionMultiplexer.Connect(connectionString);
        _cache = _redisConnection.GetDatabase();
    }

    public T Get<T>(string key)
    {
        var value = _cache.StringGet(key);
        return value.HasValue ? JsonSerializer.Deserialize<T>(value) : default;
    }

    public void Add(string key, object value, int duration)
    {
        var serializedValue = JsonSerializer.Serialize(value);
        _cache.StringSet(key, serializedValue, TimeSpan.FromMinutes(duration));
    }

    public bool IsAdd(string key)
    {
        return _cache.KeyExists(key);
    }

    public void Remove(string key)
    {
        _cache.KeyDelete(key);
    }

    public void RemoveByPattern(string pattern)
    {
        var server = _redisConnection.GetServer(_redisConnection.GetEndPoints().First());
        var keys = server.Keys(pattern: $"*{pattern}*").ToArray();
        foreach (var key in keys)
        {
            _cache.KeyDelete(key);
        }
    }
}