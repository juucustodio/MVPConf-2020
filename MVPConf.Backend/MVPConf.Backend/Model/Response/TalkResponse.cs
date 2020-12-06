using System;
using System.Collections.Generic;

namespace MVPConf.Backend.Model.Response
{
    public class TalkResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Track { get; set; }

        public DateTime Scheduler { get; set; }

        public bool Visible { get; set; }

        public List<SpeakersUrlResponse> Speakers { get; set; }

        public TalkResponse()
        {
        }
    }
}
