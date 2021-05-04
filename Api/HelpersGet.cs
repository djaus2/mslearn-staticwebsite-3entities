using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class HelpersGet
    {
        private readonly ActivityHelpersContext _context;

        public HelpersGet(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("HelpersGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "helpers")] HttpRequest req)
        {
            var helpers = await _context.Helpers.OrderBy(p => p.Name).ToArrayAsync();
            //var helpers = await helperData.GetHelpers();
            return new OkObjectResult(helpers);
        }
    }
}