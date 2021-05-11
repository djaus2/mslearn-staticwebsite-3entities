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
    public class RoundsPost
    {
        private readonly ActivityHelpersContext _context;

        public RoundsPost(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("RoundsPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "rounds")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                var round = JsonConvert.DeserializeObject<Round>(body);

                _context.Add(round);
                await _context.SaveChangesAsync();
                return new OkObjectResult(round);
            } catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
}
