using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace AzureFuncBindingErrorDemo
{
    public static class DemoFunction
    {
        [FunctionName("DemoFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Table("DemoRecords", Connection = "DemoStorageAcc")]
            CloudTable demoTable,
            ILogger log)
        {
            log.LogInformation("DemoFunction processed a request.");

            return (ActionResult)new OkObjectResult("Demo Function Result");
        }
    }
}
