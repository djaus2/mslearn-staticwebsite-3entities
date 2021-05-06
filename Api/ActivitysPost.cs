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
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var activity = JsonConvert.DeserializeObject<Activity>(body);
            activity = await Add(activity);
            return new OkObjectResult(activity);
        }

        public async Task<Activity> Add( Activity activity)
        { 

            //var helpers = _context.Helpers;
            //var rounds = _context.Rounds;
            //var activitys = _context.Activitys;

            if (activity.Helper != null)
                _context.Attach(activity.Helper); // <-- new
            _context.Attach(activity.Round);  // <-- new
            //Activity activity = acts.Single();
            //activity.Helper = activity1.Helper;
            //activity.Name = activity1.Name;
            //activity.Quantity = activity1.Quantity;
            //activity.Round = activity1.Round;
            _context.Add(activity);
            await _context.SaveChangesAsync();
            return activity;
        }
    }
}
