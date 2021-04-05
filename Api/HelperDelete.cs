using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class HelpersDelete
    {
        private readonly IHelperData helperData;

        public HelpersDelete(IHelperData helperData)
        {
            this.helperData = helperData;
        }

        [FunctionName("HelpersDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "helpers/{helperId:int}")] HttpRequest req,
            int helperId,
            ILogger log)
        {
            var result = await helperData.DeleteHelper(helperId);

            if (result)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
