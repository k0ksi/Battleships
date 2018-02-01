using Battleships.Engine;
using Battleships.Engine.Components;
using Microsoft.AspNetCore.Mvc;

namespace Battleships.Web.Controllers
{
    [Route("[controller]")]
    public class BattleshipController : Controller
    {
        [Route("PlacePlayersShips")]
        [HttpPost]
        public IActionResult PlacePlayersShips(Game game)
        {
            game.FirstPlayer = new Player("Amy");
            game.SecondPlayer = new Player("Bot");
            game.PlayerPlaceShips();
            game.ComPlayerPlaceChips();

            return this.Ok(game);
        }

        [Route("PlaceShot")]
        [HttpPost]
        public IActionResult PlaceShot([FromBody]Game game)
        {
            //ShotResult shotResult = game.PlayerPlaceShot(game.SelectedRow, game.SelectedCol);

            return this.Ok(game);
        }
    }
}
