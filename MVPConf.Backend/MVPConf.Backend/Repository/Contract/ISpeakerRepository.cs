using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVPConf.Backend.Domain;

namespace MVPConf.Backend.Repository.Contract
{
    public interface ISpeakerRepository
    {
        Task Save(Speaker speaker);

        Task Save(List<Speaker> speakers);

        Task<Speaker> GetSpeakerById(int id);

        Task<Speaker> GetSpeakerByName(string name);

        Task<List<Speaker>> GetSpeakers();
    }
}
