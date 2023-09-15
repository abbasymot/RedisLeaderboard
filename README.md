# RedisLeaderboard
This is a leaderboard using ASP.NET Core 7 webapi and Redis.

# How to run?
To get started, please clone or pull the repository.

Ensure that you have Docker and Docker-Compose installed.

Go to the RedisLeaderboard direcotry using ```cd RedisLeaderboard```.

To run the container, use the `docker-compose up --build` command. You can also add `-d` to run it in detached mode.

You can check the container's status using the `docker ps` command.

If everything is okay, you can make requests to the webapi project.

I also included my [Leaderboard Postman requests collection](https://github.com/abbasymot/RedisLeaderboard/blob/main/Leaderboard.postman_collection.json) so you can use to interact with the webapi.
