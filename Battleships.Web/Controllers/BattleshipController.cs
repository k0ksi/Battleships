using Battleships.Engine;
using Microsoft.AspNetCore.Mvc;

namespace Battleships.Web.Controllers
{
    [Route("[controller]")]
    public class BattleshipController : Controller
    {
        [Route("CompPlayerPlaceShips")]
        [HttpPost]
        public IActionResult CompPlayerPlaceShips(Game game)
        {
            game = new Game();

            return this.Ok(game);
        }
    }
}
