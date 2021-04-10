using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Api
{
    public class AppGet
    {
        private IStorage storage;
        public AppGet(IStorage _storage)
        {
            storage = _storage;
        }

        [FunctionName("AppGet")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "app")] HttpRequest req)
        {
            storage.Init();
            var activitys = storage.GetActivitys();
            return new OkObjectResult(activitys);
        }
    }
}