using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace MVPConf.Backend.Domain
{
    public class Speaker : TableEntity
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Biography { get; set; }

        public string Linkedin { get; set; }

        public string Twitter { get; set; }

        public string Site { get; set; }

        public string Photo { get; set; }

        public Speaker()
        {
        }


        public Speaker(int id, string name, string linkedin, string twitter, string site, string photo, string biography) : this()
        {
            Id = id;
            Name = name;
            Linkedin = linkedin;
            Twitter = twitter;
            Site = site;
            Photo = photo;
            Biography = biography;
            this.PartitionKey = "2020";
            this.RowKey = Id.ToString();
        }
    }
}
