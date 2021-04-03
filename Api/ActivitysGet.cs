using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Api
{
    public class ActivitysGet
    {
        private readonly IActivityData activityData;

        public ActivitysGet(IActivityData activityData)
        {
            this.activityData = activityData;
        }

        [FunctionName("ActivitysGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "activitys")] HttpRequest req)
        {
            var activitys = await activityData.GetActivitys();
            return new OkObjectResult(activitys);
        }
    }
}