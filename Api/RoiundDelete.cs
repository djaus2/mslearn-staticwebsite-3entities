﻿using System.Threading.Tasks;
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
        private readonly IRoundData roundData;
        private readonly ActivityHelpersContext _context;

        public RoundsDelete(ActivityHelpersContext context, IRoundData roundData)
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
                var allList = await _context.Rounds.ToListAsync();
                var dateList = from l in allList where l.Id == roundId select l;
                Round round = dateList.FirstOrDefault();
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
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
