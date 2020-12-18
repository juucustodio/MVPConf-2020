using System;
using MVVMCoffee.Models;

namespace MVPConfApp.Models
{
    public class Palestrante : BaseModel
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string linkedin;
        public string Linkedin
        {
            get { return linkedin; }
            set { SetProperty(ref linkedin, value); }
        }

        private string twitter;
        public string Twitter
        {
            get { return twitter; }
            set { SetProperty(ref twitter, value); }
        }
        private string site;
        public string Site
        {
            get { return site; }
            set { SetProperty(ref site, value); }
        }
        private string biography;
        public string Biography
        {
            get { return biography; }
            set { SetProperty(ref biography, value); }
        }
        private string photo;
        public string Photo
        {
            get { return photo; }
            set { SetProperty(ref photo, value); }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }

    }
}