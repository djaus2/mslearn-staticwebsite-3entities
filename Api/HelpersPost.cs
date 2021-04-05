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
    public class HelpersPost
    {
        private readonly IHelperData helperData;

        public HelpersPost(IHelperData helperData)
        {
            this.helperData = helperData;
        }

        [FunctionName("HelpersPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "helpers")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var helper = JsonSerializer.Deserialize<Helper>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var newHelper = await helperData.AddHelper(helper);
            return new OkObjectResult(newHelper);
        }
    }
}
