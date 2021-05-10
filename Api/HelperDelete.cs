using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Data;
using System.Linq;
using System;

namespace Api
{
    public class HelpersDelete
    {
        private readonly ActivityHelpersContext _context;

        public HelpersDelete(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("HelpersDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "helpers/{helperId:int}")] HttpRequest req,
            int helperId,
            ILogger log)
        {

            try
            {
                var helper = _context.Helpers
                     .Where(l => l.Id == helperId)
                     //.Include(l => l.Activitys)
                     .FirstOrDefault();
                if (helper != null)
                {
                    _context.Remove(helper);
                    var result = await _context.SaveChangesAsync();
                    if (result == 1)
                    {
                        return new OkResult();
                    }
                    else
                    {
                        return new BadRequestResult();
                    }
                }
                else
                    return new BadRequestResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
