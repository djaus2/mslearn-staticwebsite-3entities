using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class ActivitysGet
    {
        private readonly IActivityData activityData;
        private readonly ActivityHelpersContext _context;

        public ActivitysGet(ActivityHelpersContext context, IActivityData activityData)
        {
            this.activityData = activityData;
            _context = context;
        }

        [FunctionName("ActivitysGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "activitys")] HttpRequest req)
        {
            var activitys = await _context.Activitys.Include(activity=>activity.Helper).Include(activity => activity.Round).OrderBy(p => p.Round.No).ToArrayAsync();
            //var activitys = await activityData.GetActivitys();
            return new OkObjectResult(activitys);
        }
    }
}