using System;
using MVPConf.Backend.Domain;

namespace MVPConf.Backend.Model.Response
{
    public class SpeakerResponse
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Linkedin { get; set; }

        public string Twitter { get; set; }

        public string Site { get; set; }

        public string Photo { get; set; }

        public string Biography { get; set; }

        public SpeakerResponse(Speaker speaker)
        {
            Id = speaker.Id;
            Name = speaker.Name;
            Linkedin = speaker.Linkedin;
            Twitter = speaker.Twitter;
            Site = speaker.Site;
            Photo = speaker.Photo;
            Biography = speaker.Biography;
        }
    }
}
