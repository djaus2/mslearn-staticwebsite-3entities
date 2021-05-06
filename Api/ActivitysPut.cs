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
    public class ActivitysPut
    {
        private readonly ActivityHelpersContext _context;

        public ActivitysPut(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("ActivitysPut")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "activitys")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            Activity activity = JsonConvert.DeserializeObject<Activity>(body);

            if (activity != null)
            {
                if (activity.Helper != null)
                    _context.Attach(activity.Helper); // <-- new
                _context.Attach(activity.Round);  // <-- new
                _context.Update(activity);
                var result = await _context.SaveChangesAsync();
                if (result == 1)
                {
                    return new OkObjectResult(activity);
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            else
                return new BadRequestResult();
        }
    }
}
