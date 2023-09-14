namespace RedisLeaderboard.Domain.Models;

public class LeaderboardUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Stat { get; set; }
    public double Score { get; set; }
}
