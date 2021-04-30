using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class RoundsDelete
    {
        private readonly IRoundData roundData;
        private readonly BloggingContext _context;

        public RoundsDelete(BloggingContext context, IRoundData roundData)
        {
            _context = context;
            this.roundData = roundData;
        }

        [FunctionName("RoundsDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "rounds/{roundId:int}")] HttpRequest req,
            int roundId,
            ILogger log)
        {
            var result = await roundData.DeleteRound(roundId);

            if (result)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
