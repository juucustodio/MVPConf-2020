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

namespace MVPConf.Backend.Functions
{
    public class GetTalk
    {
        private ITalkService _talkService;

        public GetTalk(ITalkService talkService)
        {
            _talkService = talkService;
        }

        [FunctionName("GetTalk")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Talk/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            log.LogInformation($"Get Talk id {id}");

            var talk = await _talkService.GetTalkById(id);

            if (talk == null)
                return new NotFoundResult();

            return new OkObjectResult(talk);
        }
    }
}
