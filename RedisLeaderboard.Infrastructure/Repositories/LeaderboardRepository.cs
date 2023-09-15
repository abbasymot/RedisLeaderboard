using RedisLeaderboard.Domain.Models;
using RedisLeaderboard.Domain.Repositories;
using StackExchange.Redis;

namespace RedisLeaderboard.Infrastructure.Repositories;

public class LeaderboardRepository : ILeaderboardRepository
{
    #region Dependency Injection

    private readonly IDatabase _db;
    private const string Prefix = "leaderboard:";

    public LeaderboardRepository(RedisContext redisContext)
    {
        this._db = redisContext.Database;
    }

    #endregion

    public async Task<List<LeaderboardUser>> GetTopPlayers(string stat, long start, long stop)
    {
        var key = Prefix + stat.Trim();

        var topPlayers = await _db.SortedSetRangeByRankWithScoresAsync(key, start, stop, Order.Ascending);

        // TODO check if can use mapper instead.
        var leaderboardUser = topPlayers.Select(current => new LeaderboardUser
        {
            Username = current.Element!,
            Stat = stat,
            Score = current.Score
        }).ToList();

        return leaderboardUser;
    }

    public async Task<bool> AddScore(string username, string stat, double score)
    {
        try
        {
            var key = Prefix + stat.Trim();

            await _db.SortedSetIncrementAsync(key, username, score);
            await _db.KeyExpireAsync(key, TimeSpan.FromMinutes(5));
        }
        catch
        {
            return false;
        }

        return true;
    }
}