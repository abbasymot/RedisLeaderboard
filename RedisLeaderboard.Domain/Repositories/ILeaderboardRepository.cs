using RedisLeaderboard.Domain.Models;

namespace RedisLeaderboard.Domain.Repositories;

public interface ILeaderboardRepository
{
    Task AddScore(string username, string stat, double score);
    Task<List<LeaderboardUser>> GetTopPlayers(string stat, long start, long stop);
}