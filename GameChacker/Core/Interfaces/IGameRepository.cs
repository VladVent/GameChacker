using GameChacker.Entites;

namespace GameChacker.Core.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetGameByCompletedAsync(bool compl);
        Task<Game> GetGameByIdAsync(int id);
        Task<IReadOnlyList<Game>> GetGamesAsync();
        Task<IReadOnlyList<GamePlatform>> GetGamePlatformsAsync();
        Task<IReadOnlyList<CompletedGame>> GetCompletedGamesAsync();

        

    }
}
