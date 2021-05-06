using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data;
using System.Collections.Generic;

namespace Api
{
    public class AppGet
    {
        private readonly ActivityHelpersContext _context;

        public AppGet(ActivityHelpersContext context)
        {
            _context = context;
        }


        public async Task Clear()
        {
            bool wasChanged = false;
           // Clear any records first
            if (_context.Rounds.Count() != 0)
            {
                _context.Rounds.RemoveRange(_context.Rounds.ToList());
                wasChanged = true;
            }
            if (_context.Activitys.Count() != 0)
            {
                _context.Activitys.RemoveRange(_context.Activitys.ToList());
                wasChanged = true;
            }
            if (_context.Helpers.Count() != 0)
            {
                _context.Helpers.RemoveRange(_context.Helpers.ToList());
                wasChanged = true;
            }
            if (wasChanged)
            {
                await _context.SaveChangesAsync();
            }

            // Reset seeds
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Rounds', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Helpers', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('Activitys', RESEED, 0)");
        }


        [FunctionName("AppGet")]
        public async Task<IActionResult>  Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "app")] HttpRequest req)
        {
            await Clear();
            var activitys = _context.Activitys.ToArrayAsync();
            return new OkObjectResult("OK");
        }


    }
}