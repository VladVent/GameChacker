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

        [HttpGet("{complite}")]

        public string GetCompliteGames(bool complite)
        {
            return "return list of Complite games";
        }
    }
}
