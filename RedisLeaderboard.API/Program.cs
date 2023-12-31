using RedisLeaderboard.Application.Contracts;
using RedisLeaderboard.Application.Implementations;
using RedisLeaderboard.Domain.Repositories;
using RedisLeaderboard.Infrastructure;
using RedisLeaderboard.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var redisConnectionString = builder.Configuration.GetConnectionString("RedisConnectionString");

builder.Services.AddSingleton(new RedisContext(redisConnectionString!));
builder.Services.AddTransient<ILeaderboardRepository, LeaderboardRepository>();
builder.Services.AddTransient<ILeaderboardApplication, LeaderboardApplication>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
