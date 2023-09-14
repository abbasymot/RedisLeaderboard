using StackExchange.Redis;

namespace RedisLeaderboard.Infrastructure;

public class RedisContext
{
    private readonly ConnectionMultiplexer _redis;

    public RedisContext(string connectionString)
    {
        _redis = ConnectionMultiplexer.Connect(connectionString);
    }

    public IDatabase Database => _redis.GetDatabase();
}