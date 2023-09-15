using RedisLeaderboard.Domain.Models;

namespace RedisLeaderboard.Domain.Repositories;

public interface ILeaderboardRepository
{
    Task<List<LeaderboardUser>> GetTopPlayers(string stat, long start, long stop);
    Task<bool> AddScore(string username, string stat, double score);
}