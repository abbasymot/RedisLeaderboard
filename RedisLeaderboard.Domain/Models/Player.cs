namespace RedisLeaderboard.Domain.Models;

public class Player
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Stat { get; set; }
    public decimal Score { get; set; }
}
