using GameChacker.Data;
using GameChacker.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameChacker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameChackController : ControllerBase
    {
        private readonly GameLibraryContext _context;

        public GameChackController(GameLibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            return await GetLibraryGames();
        }

       

        [HttpGet("{_iscomplete}")]
        public async Task<ActionResult<List<Game>>> GetCompliteGames(bool _iscomplete)
        {
            var games = await GetLibraryGames();

            var _Iscompletegames = games.FirstOrDefault(game => game.IsComplete == _iscomplete);

            return Ok(_Iscompletegames);
            
        }


        private async Task<List<Game>> GetLibraryGames()
        {
            return await _context.Games.ToListAsync();
        }
    }
}
