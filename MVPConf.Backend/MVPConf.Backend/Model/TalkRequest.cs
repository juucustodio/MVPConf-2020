using System;
using System.Collections.Generic;

namespace MVPConf.Backend.Model
{
    public class TalkRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Track { get; set; }

        public bool Visible { get; set; }

        public DateTime DateTime { get; set; }

        public List<string> Speakers { get; set; }

        public TalkRequest()
        {
        }
    }
}
