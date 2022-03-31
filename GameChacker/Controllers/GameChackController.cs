using Microsoft.AspNetCore.Mvc;

namespace GameChacker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameChackController : ControllerBase
    {
        [HttpGet]
        public string GetGames()
        {
            return "return list of games";
        }

        [HttpGet("{complete}")]
        public string GetCompliteGames(bool complete)
        {
            return "return list of Complete games";
        }
    }
}
