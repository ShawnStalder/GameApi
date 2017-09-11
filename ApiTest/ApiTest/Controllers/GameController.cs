using System;
using System.Collections.Generic;
using System.Web.Http;
using ApiTest.Models;

namespace ApiTest.Controllers
{
    public class GameController : BaseApiController
    {
        [HttpGet]
        [Route("GameApi/retrieveGamesList", Name = "RetrieveGamesList")]
        public IHttpActionResult RetrieveGamesList()
        {
            try
            {
                List<GameModel> gamesList = new List<GameModel>();
                gamesList.Add(new GameModel
                {
                    Name = "Resident Evil",
                    Genre = "Horror"
                });

                gamesList.Add(new GameModel
                {
                    Name = "Rainbow Six Vegas",
                    Genre = "Awesome"
                });

                gamesList.Add(new GameModel
                {
                    Name = "Shadow Tactics: Blade of the Shogun",
                    Genre = "Strategy"
                });

                gamesList.Add(new GameModel
                {
                    Name = "Civilization V",
                    Genre = "Strategy"
                });

                return Ok(gamesList);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("GameApi/startGame", Name = "StartGame")]
        public IHttpActionResult StartGame([FromBody] GameRequest request)
        {
            // End game, updates, etc., will be handled in similar way using [HttpPost] rather than [HttpGet]

            try
            {
                /*
                 * Make the magic happen
                 * 
                 * I would probably return some sort of response (success/fail or something) as a 
                 * JSON object to allow the app to know whats going down.
                 */

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}