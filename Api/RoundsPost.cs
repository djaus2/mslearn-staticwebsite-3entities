using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using Data;

namespace Api
{
    public class RoundsPost
    {
        private readonly IRoundData roundData;
        private readonly ActivityHelpersContext _context;

        public RoundsPost(ActivityHelpersContext context, IRoundData roundData)
        {
            _context = context;
            this.roundData = roundData;
        }

        [FunctionName("RoundsPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "rounds")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var round = JsonSerializer.Deserialize<Round>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var newRound = await roundData.AddRound(round);
            return new OkObjectResult(newRound);
        }
    }
}
