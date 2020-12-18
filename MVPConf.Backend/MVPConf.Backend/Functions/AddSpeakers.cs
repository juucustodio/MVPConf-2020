using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MVPConf.Backend.Extensions;
using MVPConf.Backend.Model;
using MVPConf.Backend.Service.Contract;
using System.Linq;
using Newtonsoft.Json;

namespace MVPConf.Backend.Functions
{
    public class AddSpeakers
    {
        private readonly ISpeakerService _speakerService;

        public AddSpeakers(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [FunctionName("AddSpeakers")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Speakers")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Start Add Speakers");

            try
            {

                var body = await req.GetBodyAsync<List<SpeakerRequest>>();

                if (!body.IsValid)
                {
                    log.LogError($"Error - adding speakers"); return new BadRequestObjectResult(new { Message = string.Join(", ", body.ValidationResults.Select(s => s.ErrorMessage).ToArray()) });
                    return new BadRequestResult();
                }

                foreach (var item in body.Value)
                    log.LogInformation(JsonConvert.SerializeObject(item));

                await _speakerService.AddSpeakers(body.Value);
            }
            catch (Exception ex)
            {
                log.LogError($"Error - adding speakers"); return new BadRequestObjectResult(new { Message = ex.Message + " - " + ex.StackTrace });
                return new BadRequestResult();
            }

            return new OkResult();
        }
    }
}
