using BlazorAssemblyTravel.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace BlazorAssemblyTravel.Api
{
    public class CruiseFunction
    {
        private ICruiseService cruiseService;
        
        public CruiseFunction(ICruiseService cruiseService)
        {
            this.cruiseService = cruiseService;
        }
        
        [FunctionName("CruiseDeals")]
        public async Task<IActionResult> GetCruiseDeals(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var cruiseDeals = await cruiseService.GetCruiseDeals();

            return new OkObjectResult(cruiseDeals);
        }
        
        [FunctionName("CruiseLines")]
        public async Task<IActionResult> GetCruiseLines(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var cruiseLines = await cruiseService.GetCruiseLines();

            return new OkObjectResult(cruiseLines);
        }
        
        [FunctionName("Destinations")]
        public async Task<IActionResult> GetDestinations(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var destinations = await cruiseService.GetDestinations();

            return new OkObjectResult(destinations);
        }
    }
}