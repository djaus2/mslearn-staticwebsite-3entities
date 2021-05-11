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
    public class HelpersPost
    {
        private readonly ActivityHelpersContext _context;

        public HelpersPost(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("HelpersPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "helpers")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                var helper = JsonConvert.DeserializeObject<Helper>(body);
                if (helper != null)
                {
                    _context.Add(helper);
                    await _context.SaveChangesAsync();
                    return new OkObjectResult(helper);
                }
                else
                    return new BadRequestResult();
            } catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
}
