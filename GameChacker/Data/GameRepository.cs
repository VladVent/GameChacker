using GameChacker.Core.Interfaces;
using GameChacker.Entites;
using Microsoft.EntityFrameworkCore;

namespace GameChacker.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly GameLibraryContext _context;

        public GameRepository(GameLibraryContext context)
        {
            _context = context;
        }

        public async Task<Game> GetGameByCompletedAsync(bool com)
        {
            return await _context.Games.FindAsync(com);
        }

        public Task<Game> GetGameByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }
    }
}
