using RedisLeaderboard.Domain.Models;
using RedisLeaderboard.Domain.Repositories;

namespace RedisLeaderboard.Infrastructure.Repositories;

public class LeaderboardRepository : ILeaderboardRepository
{
    public Task AddScore(string username, string stat, decimal score)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaderboardUser>> GetTopPlayers(string stat)
    {
        throw new NotImplementedException();
    }
}