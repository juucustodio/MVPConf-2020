﻿using System;
namespace MVPConf.Backend.Model.Response
{
    public class SpeakersUrlResponse
    {
        public string Name { get; set; }

        public string Url { get; private set; }

        public SpeakersUrlResponse(string name, int id)
        {
            Name = name;
            Url = $"/Speaker/{id}";
        }
    }
}
