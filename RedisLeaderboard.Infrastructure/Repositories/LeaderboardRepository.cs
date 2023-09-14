using RedisLeaderboard.Domain.Models;
using RedisLeaderboard.Domain.Repositories;
using StackExchange.Redis;

namespace RedisLeaderboard.Infrastructure.Repositories;

public class LeaderboardRepository : ILeaderboardRepository
{
    #region Dependency Injection

    private readonly IDatabase _db;

    public LeaderboardRepository(RedisContext redisContext)
    {
        this._db = redisContext.Database;
    }

    #endregion

    public Task AddScore(string username, string stat, decimal score)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaderboardUser>> GetTopPlayers(string stat)
    {
        throw new NotImplementedException();
    }
}