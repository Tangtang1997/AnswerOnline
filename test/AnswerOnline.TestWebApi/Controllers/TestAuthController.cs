using System.Net.Http;
using Xunit.Abstractions;

namespace AnswerOnline.TestWebApi.Controllers
{
    public class TestAuthController : TestApiControllerBase
    {
        public HttpClient TestHttpClient { get; }
        public ITestOutputHelper OutputHelper { get; }

        public TestAuthController(ITestOutputHelper outputHelper)
        {
            TestHttpClient = GetClient();
            OutputHelper = outputHelper;
        }

        
    } 
}