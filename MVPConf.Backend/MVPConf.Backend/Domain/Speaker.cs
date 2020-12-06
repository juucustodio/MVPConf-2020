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
                this.RowKey = _id.ToString();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.PartitionKey = _name;
            }
        }

        public string Linkedin { get; set; }

        public string Twitter { get; set; }

        public string Site { get; set; }

        public string Photo { get; set; }

        public Speaker()
        {
        }


        public Speaker(int id, string name, string linkedin, string twitter, string site, string photo) : this()
        {
            Id = id;
            Name = name;
            Linkedin = linkedin;
            Twitter = twitter;
            Site = site;
            Photo = photo;
        }
    }
}
