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
using Newtonsoft.Json;

namespace Api
{
    public class ActivitysPost
    {
        private readonly ActivityHelpersContext _context;

        public ActivitysPost(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("ActivitysPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "activitys")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                var activity = JsonConvert.DeserializeObject<Activity>(body);
                if (activity.Helper != null)
                    _context.Attach(activity.Helper);
                _context.Attach(activity.Round);
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return new OkObjectResult(activity);
            } catch(Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
}
