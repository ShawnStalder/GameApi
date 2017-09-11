using System.Text;
using System.Net;
using System.Web.Mvc;
using System.Web.Configuration;

namespace GameApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Protected Enums
        protected enum Accept
        {
            None = 0,
            Json = 1,
            File = 2
        }

        protected enum ContentType
        {
            None = 0,
            FormData = 1,
            File = 2,
            Json
        }
        #endregion Protected Enums

        protected static WebClient GetWebClient(Accept accept = Accept.None, ContentType contentType = ContentType.None)
        {
            WebClient client = new WebClient
            {
                Encoding = Encoding.UTF8,
                UseDefaultCredentials = true,
                BaseAddress = WebConfigurationManager.AppSettings["GuarantyRewardsApi:WebApiBaseAddress"]
            };

            client.Headers.Clear();

            switch (accept)
            {
                case Accept.Json:
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    break;

                case Accept.File:
                    client.Headers.Add(HttpRequestHeader.Accept, "application/octet-stream");
                    break;
            }

            switch (contentType)
            {
                case ContentType.Json:
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    break;

                case ContentType.File:
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/octet-stream");
                    break;

                case ContentType.FormData:
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    break;
            }
            return client;
        }
    }
}
