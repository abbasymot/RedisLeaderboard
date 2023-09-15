using RedisLeaderboard.Application.ViewModels;

namespace RedisLeaderboard.Application.Contracts;

public interface ILeaderboardApplication
{
    Task<List<LeaderboardUserVM>> GetTopPlayers(string stat);
    Task<bool> AddScore(string username, string stat, double score);
}