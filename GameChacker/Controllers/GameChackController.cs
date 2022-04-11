using GameChacker.Core.Interfaces;
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
        private readonly IGameRepository _repo;

        public GameChackController(IGameRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            var games = await _repo.GetGamesAsync();
            return Ok(games);
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Game>>> GetGameById(int Id)
        {
            var game = await _repo.GetGameByIdAsync(Id);
            return Ok(game);

        }

        [HttpGet("platform")]

        public async Task<ActionResult<IReadOnlyList<GamePlatform>>> GetGamePlatforms()
        {
            return Ok(await _repo.GetGamePlatformsAsync());
        }

        [HttpGet("completed")]

        public async Task<ActionResult<IReadOnlyList<CompletedGame>>> GetCompletedGame()
        {
            return Ok(await _repo.GetCompletedGamesAsync());
        }

        [HttpGet("game/{comp}")]

        public async Task<ActionResult<IReadOnlyList<Game>>> GetAllCompletedGames(bool comp)
        {
            return Ok(await _repo.GetGameByCompletedAsync(comp));            
        }

    }
}
