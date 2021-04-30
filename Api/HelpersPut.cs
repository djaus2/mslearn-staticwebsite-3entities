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
    public class HelpersPut
    {
        private readonly IHelperData helperData;
        private readonly ActivityHelpersContext _context;

        public HelpersPut(ActivityHelpersContext context, IHelperData helperData)
        {
            this.helperData = helperData;
            _context = context;
        }

        [FunctionName("HelpersPut")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "helpers")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var helper = JsonSerializer.Deserialize<Helper>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var updatedHelper = await helperData.UpdateHelper(helper);
            return new OkObjectResult(updatedHelper);
        }
    }
}
