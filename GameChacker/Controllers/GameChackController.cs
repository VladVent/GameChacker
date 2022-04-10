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
            var games  = await _repo.GetGamesAsync();
            return Ok(games);
        }

       

        [HttpGet("{_iscomplete}")]
        public async Task<ActionResult<List<Game>>> GetCompliteGames(bool _iscomplete)
        {
            var comp = await _repo.GetGameByCompletedAsync(_iscomplete);
            return Ok(comp);
            
        }
    }
}
