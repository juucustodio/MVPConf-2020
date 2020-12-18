using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MVPConf.Backend.Service.Contract;
using System.Linq;

namespace MVPConf.Backend.Functions
{
    public class GetTalks
    {
        private readonly ITalkService _talkService;

        public GetTalks(ITalkService talkService)
        {
            _talkService = talkService;
        }

        [FunctionName("GetTalks")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Talk")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Get Talks");

            var talks = await _talkService.GetTalks();

            if (talks == null || !talks.Any())
                return new NoContentResult();

            return new OkObjectResult(talks);
        }
    }
}
