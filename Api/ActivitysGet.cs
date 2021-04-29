using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class ActivitysGet
    {

        private readonly BloggingContext _context;
        public ActivitysGet(BloggingContext context)
        {
            _context = context;
        }

        [FunctionName("ActivitysGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "activitys")] HttpRequest req)
        {
            var activitys = await _context.Activitys.OrderBy(p => p.Id).ToArrayAsync();
            return new OkObjectResult(activitys);
        }
    }
}