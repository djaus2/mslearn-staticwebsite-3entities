using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Data;
using System.Linq;
using System;

namespace Api
{
    public class ActivitysDelete
    {
        private readonly ActivityHelpersContext _context;

        public ActivitysDelete(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("ActivitysDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "activitys/{activityId:int}")] HttpRequest req,
            int activityId,
            ILogger log)
        {
            try
            {
                var activity = _context.Activitys
                     .Where(l => l.Id == activityId)
                     .FirstOrDefault();
                if (activity != null)
                {
                    _context.Remove(activity);
                    var result = await _context.SaveChangesAsync();
                    if (result == 1)
                    {
                        return new OkResult();
                    }
                    else
                    {
                        return new BadRequestResult();
                    }
                }
                else
                    return new BadRequestResult();
            } catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
