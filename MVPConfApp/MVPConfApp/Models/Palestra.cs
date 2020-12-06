using System;
using System.Collections.Generic;

namespace MVPConfApp.Models
{
    public class Palestra
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Track { get; set; }
        public bool Visible { get; set; }
        public string Scheduler { get; set; }
        public List<string> Speakers { get; set; }
        //public List<Palestrante> Speakers { get; set; }
        public DateTime DateTime { get; set; }

    }
}