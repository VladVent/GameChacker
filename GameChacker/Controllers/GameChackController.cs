using AutoMapper;
using GameChacker.Core.Interfaces;
using GameChacker.Core.Specifications;
using GameChacker.Data;
using GameChacker.Dtos;
using GameChacker.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameChacker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameChackController : ControllerBase
    {
        private readonly IGenericRepository<Game> gamerepo;
        private readonly IGenericRepository<GamePlatform> platformrepo;
        private readonly IGenericRepository<CompletedGame> completedrepo;
        private readonly IMapper mapper;

        public GameChackController(IGenericRepository<Game> gamerepo, 
            IGenericRepository<GamePlatform> platformrepo, IGenericRepository<CompletedGame> completedrepo, IMapper mapper)
        {
            this.gamerepo = gamerepo;
            this.platformrepo = platformrepo;
            this.completedrepo = completedrepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GameToReturnDto>>> GetGames()
        {
            var spec = new GameWithCompletedandPlatformSpecification();

            var games = await gamerepo.ListAsync(spec);

            return Ok(mapper
                .Map<IReadOnlyList<Game>, IReadOnlyList<GameToReturnDto>>(games));
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult<GameToReturnDto>> GetGameById(int Id)
        {

            var spec = new GameWithCompletedandPlatformSpecification(Id);

            var game = await gamerepo.GetEntityWithSpec(spec);

            return mapper.Map<Game, GameToReturnDto>(game);


        }

        [HttpGet("platform")]

        public async Task<ActionResult<IReadOnlyList<GamePlatform>>> GetGamePlatforms()
        {
            return Ok(await platformrepo.ListAllAsync());
        }

        [HttpGet("completed")]

        public async Task<ActionResult<IReadOnlyList<CompletedGame>>> GetCompletedGame()
        {
            return Ok(await completedrepo.ListAllAsync());
        }

        //[HttpGet("game/{comp}")]

        //public async Task<ActionResult<IReadOnlyList<Game>>> GetAllCompletedGames(bool comp)
        //{
        //    return Ok(await _repo.GetGameByCompletedAsync(comp));            
        //}

    }
}
