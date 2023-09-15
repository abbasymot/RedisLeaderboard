using RedisLeaderboard.Application.ViewModels;

namespace RedisLeaderboard.Application.Contracts;

public interface ILeaderboardApplication
{
    List<LeaderboardUserVM> GetTopPlayers(string stat);
    Task AddScore(string username, string stat, double score);
}