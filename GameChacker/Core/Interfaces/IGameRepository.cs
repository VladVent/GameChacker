using GameChacker.Entites;

namespace GameChacker.Core.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetGameByCompletedAsync(bool com);
        Task<Game> GetGameByIdAsync(int id);
        Task<IReadOnlyList<Game>> GetGamesAsync();
    }
}
