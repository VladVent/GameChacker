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

        public async Task<IReadOnlyList<CompletedGame>> GetCompletedGamesAsync()
        {
            return await _context.CompletedGames.ToListAsync();
        }

        public async Task<Game> GetGameByCompletedAsync(int com)
        {
            return await _context.Games.FindAsync(com);
        }

        public async Task<IReadOnlyList<Game>> GetGameByCompletedAsync(bool compl)
        {
            return await _context.Games
                 .Include(g => g.CompletedGames)
                 .Include(g => g.Platform)
                 .Where(g => g.CompletedGames.IsGameCompleted == compl).ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games
                .Include(g => g.CompletedGames)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(g=>g.Id == id);
        }

        public async Task<IReadOnlyList<GamePlatform>> GetGamePlatformsAsync()
        {
            return await _context.GamePlatforms.ToListAsync();
        }

        public async Task<IReadOnlyList<Game>> GetGamesAsync()
        {
            var completeId = 1;

            var games = _context.Games.
                Where(x => x.CompletedGameId == completeId).Include(x=>x.CompletedGames).ToListAsync();


            return await _context.Games
                .Include(g=> g.CompletedGames)
                .Include(g => g.Platform)
                .ToListAsync();
        }
    }
}
