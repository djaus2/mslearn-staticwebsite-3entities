using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Api
{
    public class RoundsGet
    {
        private readonly IRoundData roundData;

        public RoundsGet(IRoundData roundData)
        {
            this.roundData = roundData;
        }

        [FunctionName("RoundsGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rounds")] HttpRequest req)
        {
            var rounds = await roundData.GetRounds();
            return new OkObjectResult(rounds);
        }
    }
}