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
    public class RoundsDelete
    {
        private readonly ActivityHelpersContext _context;

        public RoundsDelete(ActivityHelpersContext context)
        {
            _context = context;
        }

        [FunctionName("RoundsDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "rounds/{roundId:int}")] HttpRequest req,
            int roundId,
            ILogger log)
        {
            //var result = await roundData.DeleteRound(roundId);

            //if (result)
            //{
            //    return new OkResult();
            //}
            //else
            //{
            //    return new BadRequestResult();
            //}
            try
            {

                var round = _context.Rounds
                    .Where(l => l.Id == roundId)
                    //.Include(l => l.Activitys)
                    .FirstOrDefault();

                if (round != null)
                {
                    _context.Remove(round);
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
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
}
