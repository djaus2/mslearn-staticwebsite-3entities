using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using Data;

namespace Api
{
    public class ActivitysPost
    {
        private readonly IActivityData activityData;
        private readonly ActivityHelpersContext _context;

        public ActivitysPost(ActivityHelpersContext context, IActivityData activityData)
        {
            this.activityData = activityData;
            _context = context;
        }

        [FunctionName("ActivitysPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "activitys")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var activity = JsonSerializer.Deserialize<Activity>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var newActivity = await activityData.AddActivity(activity);
            return new OkObjectResult(newActivity);
        }
    }
}
