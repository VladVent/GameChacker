using GameChacker.Entites;
using System.IO;
using System.Text.Json;

namespace GameChacker.Data
{
    public class GameSeedContext
    {
        public static  async Task SeedAsync(GameLibraryContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.GamePlatforms.Any())
                {
                    var platformData = 
                        File.ReadAllText("../GameChacker/Data/SeedData/GamePlatform.json");

                    var platforms = JsonSerializer.Deserialize<List<GamePlatform>>(platformData);

                    foreach (var platform in platforms)
                    {
                        context.GamePlatforms.Add(platform);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.CompletedGames.Any())
                {
                    var completeData =
                        File.ReadAllText("../GameChacker/Data/SeedData/CompletedGames.json");

                    var completed = JsonSerializer.Deserialize<List<CompletedGame>>(completeData);

                    foreach (var c in completed)
                    {
                        context.CompletedGames.Add(c);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Games.Any())
                {
                    var gameData =
                        File.ReadAllText("../GameChacker/Data/SeedData/Games.json");

                    var games = JsonSerializer.Deserialize<List<Game>>(gameData);

                    foreach (var g in games)
                    {
                        context.Games.Add(g);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<GameSeedContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
