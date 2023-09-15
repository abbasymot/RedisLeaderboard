using RedisLeaderboard.Application.Contracts;
using RedisLeaderboard.Application.ViewModels;

namespace RedisLeaderboard.Application.Implementations;

public class LeaderboardApplication : ILeaderboardApplication
{
    public Task AddScore(string username, string stat, double score)
    {
        throw new NotImplementedException();
    }

    public List<LeaderboardUserVM> GetTopPlayers(string stat)
    {
        throw new NotImplementedException();
    }
}