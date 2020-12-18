using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVPConf.Backend.Model;
using MVPConf.Backend.Model.Response;

namespace MVPConf.Backend.Service.Contract
{
    public interface ISpeakerService
    {
        Task<SpeakerResponse> GetSpeakerById(int speakerId);

        Task<List<SpeakerResponse>> GetSpeakers();

        Task AddSpeakers(List<SpeakerRequest> speakersRequest);
    }
}
