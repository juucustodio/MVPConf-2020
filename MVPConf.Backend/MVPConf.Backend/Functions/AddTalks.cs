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
using MVPConf.Backend.Extensions;
using MVPConf.Backend.Model;
using System.Collections.Generic;
using System.Linq;

namespace MVPConf.Backend.Functions
{
    public class AddTalks
    {
        private readonly ITalkService _talkService;

        public AddTalks(ITalkService talkService)
        {
            _talkService = talkService;
        }

        [FunctionName("AddTalks")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Talks")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Start Add Talks");

            try
            {

                var body = await req.GetBodyAsync<List<TalkRequest>>();

                if (!body.IsValid)
                {
                    log.LogError($"Error - adding talks"); return new BadRequestObjectResult(new { Message = string.Join(", ", body.ValidationResults.Select(s => s.ErrorMessage).ToArray()) });
                    return new BadRequestResult();
                }

                foreach (var item in body.Value)
                    log.LogInformation(JsonConvert.SerializeObject(item));

                await _talkService.AddTalks(body.Value);
            }
            catch (Exception ex)
            {
                log.LogError($"Error - adding talks"); return new BadRequestObjectResult(new { Message = ex.Message +" - " +ex.StackTrace });
                return new BadRequestResult();
            }

            return new OkResult();
        }
    }
}
