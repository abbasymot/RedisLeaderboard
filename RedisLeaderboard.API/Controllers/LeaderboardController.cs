using Microsoft.AspNetCore.Mvc;
using RedisLeaderboard.Application.Contracts;

namespace RedisLeaderboard.API.Controllers;

[ApiController]
[Route("api/leaderboard/[action]")]
public class LeaderboardController : ControllerBase
{
    #region Dependency Injection

    private readonly ILeaderboardApplication _leaderboardApplication;

    public LeaderboardController(ILeaderboardApplication leaderboardApplication)
    {
        this._leaderboardApplication = leaderboardApplication;
    }

    #endregion

    [HttpGet]
    public async Task<IActionResult> GetTopPlayers([FromQuery] string stat)
    {
        var topPlayers = await _leaderboardApplication.GetTopPlayers(stat);
        return Ok(topPlayers);
    }

    [HttpPost]
    public async Task<IActionResult> AddScore([FromQuery] string username, [FromQuery] string stat, [FromQuery] double score)
    {
        var result = await _leaderboardApplication.AddScore(username, stat, score);

        if (result == false)
        {
            return BadRequest();
        }

        return Ok();
        // return CreatedResult();
    }
}