using System;
namespace MVPConf.Backend.Model
{
    public class SpeakerRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Linkedin { get; set; }

        public string Twitter { get; set; }

        public string Site { get; set; }

        public string Biography { get; set; }

        public string Photo { get; set; }

        public SpeakerRequest()
        {
        }
    }
}
