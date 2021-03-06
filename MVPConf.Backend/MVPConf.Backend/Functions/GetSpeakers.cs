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
    public class GetSpeakers
    {
        private readonly ISpeakerService _speakerService;

        public GetSpeakers(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [FunctionName("GetSpeakers")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Speaker")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Get Speakers");

            var speakers = await _speakerService.GetSpeakers();

            if (speakers == null || !speakers.Any())
                return new NoContentResult();

            return new OkObjectResult(speakers);
        }
    }
}
