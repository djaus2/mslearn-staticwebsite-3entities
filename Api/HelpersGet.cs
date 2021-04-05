using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Api
{
    public class HelpersGet
    {
        private readonly IHelperData helperData;

        public HelpersGet(IHelperData helperData)
        {
            this.helperData = helperData;
        }

        [FunctionName("HelpersGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "helpers")] HttpRequest req)
        {
            var helpers = await helperData.GetHelpers();
            return new OkObjectResult(helpers);
        }
    }
}