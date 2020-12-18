using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVPConf.Backend.Model.Response;
using MVPConf.Backend.Repository.Contract;
using System.Linq;
using MVPConf.Backend.Service.Contract;
using MVPConf.Backend.Model;
using MVPConf.Backend.Domain;
using System.Text;

namespace MVPConf.Backend.Service
{
    public class TalkService : ITalkService
    {
        private readonly ITalkRepository _talkRepository;
        private readonly ISpeakerRepository _speakerRepository;

        public TalkService(ITalkRepository talkRepository, ISpeakerRepository speakerRepository)
        {
            _talkRepository = talkRepository;
            _speakerRepository = speakerRepository;
        }

        public async Task<List<TalkResponse>> GetTalks()
        {
            var talks = await _talkRepository.GetTalks();

            List<TalkResponse> talksReponse = new List<TalkResponse>();

            if (talks == null || !talks.Any())
                return talksReponse;

            foreach(var item in talks)
            { 
                var tr = new TalkResponse(item);

                tr.Speakers = await GetSpeakers(item.Speakers);

                talksReponse.Add(tr);
            };

            return talksReponse;
        }

        public async Task<TalkResponse> GetTalkById(int id)
        {
            var talk = await _talkRepository.GetTalkById(id);

            if (talk == null)
                return null;

            TalkResponse talkResponse = new TalkResponse(talk);
            talkResponse.Speakers = await GetSpeakers(talk.Speakers);

            return talkResponse;
        }

        public async Task AddTalks(List<TalkRequest> talksRequest)
        {
            List<Talk> talks = new List<Talk>();
            foreach(var tr in talksRequest)
            {
                var talk = new Talk(tr.Id, tr.Title, tr.Track, tr.DateTime, tr.Visible);

                await SetSpeakersId(tr.Speakers, talk);

                var existingTalk = await _talkRepository.GetTalkById(talk.Id);

                if (existingTalk == null)
                    talks.Add(talk);
            }

            await _talkRepository.Save(talks);
        }

        private async Task SetSpeakersId(List<string> speakersList, Talk talk)
        {
            StringBuilder spIds = new StringBuilder();

            foreach(var sName in speakersList)
            {
                var speaker = await _speakerRepository.GetSpeakerByName(sName);

                if (speaker != null)
                    talk.AddSpeaker(speaker.Id);
            }
        }

        private async Task<List<SpeakersUrlResponse>> GetSpeakers(string speakers)
        {
            List<SpeakersUrlResponse> speakersUrlResponses = new List<SpeakersUrlResponse>();

            if (!string.IsNullOrEmpty(speakers))
            {
                var speakersId = speakers.Split(',');

                if (speakersId != null)
                {
                    foreach(var code in speakersId)
                    {
                        var s = await _speakerRepository.GetSpeakerById(int.Parse(code.Trim()));

                        if (s != null)
                            speakersUrlResponses.Add(new SpeakersUrlResponse(s.Name, int.Parse(code.Trim())));
                    }
                }
            }

            return speakersUrlResponses;
        }
    }
}
