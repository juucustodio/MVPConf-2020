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
    public class GetSpeaker
    {
        private readonly ISpeakerService _speakerService;

        public GetSpeaker(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [FunctionName("GetSpeaker")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Speaker/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            log.LogInformation($"Get Speaker id {id}");

            var speaker = await _speakerService.GetSpeakerById(id);


            log.LogInformation(JsonConvert.SerializeObject(speaker));

            if (speaker == null)
                return new NotFoundResult();

            return new OkObjectResult(speaker);
        }
    }
}
