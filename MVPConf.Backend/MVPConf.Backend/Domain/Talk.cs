using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace MVPConf.Backend.Domain
{
    public class Talk : TableEntity
    {
        private int _id;
        private string _title;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                this.RowKey = _id.ToString();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                this.PartitionKey = _title;
            }
        }

        public string Track { get; set; }

        public DateTime Scheduler { get; set; }

        public bool Visible { get; set; }

        public string Speakers { get; private set; }


        public void AddSpeaker(int speakerId)
        {
            if (!string.IsNullOrEmpty(Speakers))
            {
                Speakers += $",{speakerId}";
                return;
            }

            Speakers = speakerId.ToString();
        }

        public Talk()
        {
            
        }

        public Talk(int id, string title, string track, DateTime scheduler, bool visible)
        {
            Id = id;
            Title = title;
            Track = track;
            Scheduler = scheduler;
            Visible = visible;
        }
    }
}
