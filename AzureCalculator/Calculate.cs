using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Domain;

namespace AzureCalculator
{
    public static class Calculate
    {
        [FunctionName("Calculate")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "triangle/{first:int}/{second:int}/{third:int}")] HttpRequest req,
            int first, int second, int third, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (first <= 0 || second <= 0 || third <= 0)
            {
                return new BadRequestObjectResult("All side lengths must be greater than zero.");
            }

            var triangle = new Triangle(first, second, third);
            return new JsonResult(triangle.Type.ToString());
        }
    }
}
