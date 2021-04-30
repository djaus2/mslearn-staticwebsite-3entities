using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Data;
using System.Linq;
using System;

namespace Api
{
    public class ActivitysPut
    {
        private readonly IActivityData activityData;
        private readonly ActivityHelpersContext _context;

        public ActivitysPut(ActivityHelpersContext context, IActivityData activityData)
        {
            this.activityData = activityData;
            _context = context;
        }

        [FunctionName("ActivitysPut")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "activitys")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var activity = JsonSerializer.Deserialize<Activity>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var updatedActivity = await activityData.UpdateActivity(activity);
            return new OkObjectResult(updatedActivity);
        }
    }
}
