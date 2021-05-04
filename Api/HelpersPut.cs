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
    public class HelpersPut
    {
        private readonly ActivityHelpersContext _context;

        public HelpersPut(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("HelpersPut")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "helpers")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            Helper helper = JsonConvert.DeserializeObject<Helper>(body);

            if (helper != null)
            {
                _context.Update(helper);
                var result = await _context.SaveChangesAsync();
                if (result == 1)
                {
                    return new OkObjectResult(helper);
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
