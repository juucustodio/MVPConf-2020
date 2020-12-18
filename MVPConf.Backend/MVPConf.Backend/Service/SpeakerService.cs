using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVPConf.Backend.Model.Response;
using MVPConf.Backend.Repository.Contract;
using System.Linq;
using MVPConf.Backend.Service.Contract;
using MVPConf.Backend.Model;
using MVPConf.Backend.Domain;

namespace MVPConf.Backend.Service
{
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _repository;

        public SpeakerService(ISpeakerRepository speakerRepository)
        {
            _repository = speakerRepository;
        }

        public async Task<SpeakerResponse> GetSpeakerById(int speakerId)
        {
            var speaker = await _repository.GetSpeakerById(speakerId);

            if (speaker == null)
                return null;

            return new SpeakerResponse(speaker);
        }

        public async Task<List<SpeakerResponse>> GetSpeakers()
        {
            var speakers = await _repository.GetSpeakers();

            List<SpeakerResponse> speakerResponses = new List<SpeakerResponse>();

            speakers.ForEach(s => speakerResponses.Add(new SpeakerResponse(s)));

            return speakerResponses;
        }

        public async Task AddSpeakers(List<SpeakerRequest> speakersRequest)
        {
            List<Speaker> speakers = new List<Speaker>();
            foreach (var s in speakersRequest)
            {
                var speaker = new Speaker(s.Id, s.Title, s.Linkedin, s.Twitter, s.Site, s.Photo, s.Biography);

                var existingSpeaker = await _repository.GetSpeakerByName(speaker.Name);

                if (existingSpeaker == null)
                    speakers.Add(speaker);
            }

            await _repository.Save(speakers);
        }

    }
}
