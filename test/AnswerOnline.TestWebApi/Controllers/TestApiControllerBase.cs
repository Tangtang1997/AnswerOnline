using System.IO;
using System.Net.Http;
using AnswerOnline.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace AnswerOnline.TestWebApi.Controllers
{
    public class TestApiControllerBase
    {
        public static HttpClient GetClient()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseEnvironment("Testing");
            var server = new TestServer(webHostBuilder);

            return server.CreateClient();
        }
    }
}