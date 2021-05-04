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
    public class RoundsPut
    {
        private readonly ActivityHelpersContext _context;

        public RoundsPut(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("RoundsPut")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "rounds")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var round = JsonConvert.DeserializeObject<Round>(body);

            if (round != null)
            {
                _context.Update(round);
                var result = await _context.SaveChangesAsync();
                if (result == 1)
                {
                    return new  OkObjectResult(round);
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
