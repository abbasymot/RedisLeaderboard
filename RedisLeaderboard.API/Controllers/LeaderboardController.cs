using Microsoft.AspNetCore.Mvc;
using RedisLeaderboard.Domain.Repositories;

namespace RedisLeaderboard.API.Controllers;

[ApiController]
[Route("api/leaderboard/[action]")]
public class LeaderboardController : ControllerBase
{
    #region Dependency Injection

    private readonly ILeaderboardRepository _repo;

    public LeaderboardController(ILeaderboardRepository repo)
    {
        _repo = repo;
    }

    #endregion

    [HttpGet]
    public async Task<IActionResult> GetTopPlayers([FromQuery] string stat)
    {
        var topPlayers = await _repo.GetTopPlayers(stat, 0, 19);
        return Ok(topPlayers);
    }

    [HttpPost]
    public async Task<IActionResult> AddScore([FromQuery] string username, [FromQuery] string stat, [FromQuery] double score)
    {
        await _repo.AddScore(username, stat, score);
        return Ok();
    }
}