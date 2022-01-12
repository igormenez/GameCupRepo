using System;
using System.Collections.Generic;
using System.Linq;
using GameCup.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameCup.Controllers
{
    [ApiController]
    [Route("v1")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [HttpPost]
        public async Task<ActionResult<List<Game>>> PostAsync(
            [FromBody] List<Game> game_param
            )
        {

            if ( game_param.Count != 8 )
            {
                return BadRequest("Invalid quantity games");
            }
            game_param.Sort((a, b) => a.titulo.CompareTo(b.titulo));

            var game_response = new List<Game>();
            var game = new Game();

            game_response = game.Final(game.Eliminatorias(game_param));

            return Ok(game_response);
        }
    }
}
