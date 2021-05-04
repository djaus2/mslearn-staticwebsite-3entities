using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class RoundsGet
    {
        private readonly ActivityHelpersContext _context;

        public RoundsGet(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("RoundsGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rounds")] HttpRequest req)
        {
            var rounds = await _context.Rounds.OrderBy(p => p.No).ToArrayAsync();
            //var rounds = await roundData.GetRounds();
            return new OkObjectResult(rounds);
        }
    }
}