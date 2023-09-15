using RedisLeaderboard.Application.Contracts;
using RedisLeaderboard.Application.ViewModels;
using RedisLeaderboard.Domain.Models;
using RedisLeaderboard.Domain.Repositories;

namespace RedisLeaderboard.Application.Implementations;

public class LeaderboardApplication : ILeaderboardApplication
{
    #region Dependency Injection

    private readonly ILeaderboardRepository _leaderboardRepository;

    public LeaderboardApplication(ILeaderboardRepository leaderboardRepository)
    {
        this._leaderboardRepository = leaderboardRepository;
    }

    #endregion

    public async Task<List<LeaderboardUserVM>> GetTopPlayers(string stat)
    {
        var topPlayers = await _leaderboardRepository.GetTopPlayers(stat, 0, 19);

        if (topPlayers == null || topPlayers.Count == 0)
        {
            return new List<LeaderboardUserVM>();
        }

        return Mapp(topPlayers);
    }

    public async Task<bool> AddScore(string username, string stat, double score)
    {
        if (score == 0)
        {
            return false;
        }

        var result = await _leaderboardRepository.AddScore(username, stat, score);
        return result;
    }

    private List<LeaderboardUserVM> Mapp(List<LeaderboardUser> leaderboardUsers)
    {
        // I wanted to use AutoMapper but think manually mapping is faster than that.

        var output = new List<LeaderboardUserVM>();

        foreach (var leaderboardUser in leaderboardUsers)
        {
            output.Add(new LeaderboardUserVM
            {
                Username = leaderboardUser.Username,
                Stat = leaderboardUser.Stat,
                Score = leaderboardUser.Score,
            });
        }

        return output;
    }
}