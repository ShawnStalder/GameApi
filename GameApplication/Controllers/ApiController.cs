using System;
using System.Collections.Generic;
using System.Net;
using GameApplication.Models;
using Newtonsoft.Json;

namespace GameApplication.Controllers
{
    public class ApiController : BaseController
    {
        public static List<GameModel> RetrieveGamesList()
        {
            try
            {
                string json;
                using (WebClient client = GetWebClient(Accept.Json, ContentType.Json))
                {
                    json = client.DownloadString("RetrieveGamesList");
                }

                List<GameModel> gamesList = JsonConvert.DeserializeObject<List<GameModel>>(json);
                return gamesList;
            }
            catch (Exception ex)
            {
                // Log errors and do stuff...
                return null;
            }
        }

        public static bool StartGame()
        {
            try
            {
                GameRequest request = new GameRequest
                {
                    Name = "Rainbow Six Vegas",
                    Action = "Run" // could be stop, pause, etc.
                };

                string postBody = JsonConvert.SerializeObject(request);
                string json;
                using (WebClient client = GetWebClient(Accept.Json, ContentType.Json))
                {
                    // Could be EndGame, PauseGame, whatever you've created in your end point.
                    json = client.UploadString("StartGame", "POST", postBody);
                }

                return json == "successful";
            }
            catch (Exception ex)
            {
                // KABOOM!
                return false;
            }
        }
    }
}
