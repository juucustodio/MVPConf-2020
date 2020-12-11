using System;
using System.Collections.Generic;
using MVVMCoffee.Models;

namespace MVPConfApp.Models
{
    public class Palestra : BaseModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string TitleLabel
        {
            get
            {
                return Title.Replace("[EN]", "").Replace("[PT-BR]", "").Replace("[ES]", "").Trim();
            }

        }

        public string Description { get; set; }
        public string Track { get; set; }
        public Track TrackObj { get; set; }
        public bool Visible { get; set; }
        public string Scheduler { get; set; }
        public List<Palestrante> Speakers { get; set; }
        public string SpeakersLabel {
            get 
            {
                var txt = "";
                if (Speakers.Count > 0)
                {
                    foreach (var spk in Speakers)
                        txt += spk.Name + " | ";
                }
                return txt;
            } 
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }
        
        public string Flag
        {
            get
            {
                if (Title.Contains("[EN]"))
                    return "🇺🇸";
                else if (Title.Contains("[ES]"))
                    return "🇪🇸";

                return "🇧🇷";
            }
        }

    }
}