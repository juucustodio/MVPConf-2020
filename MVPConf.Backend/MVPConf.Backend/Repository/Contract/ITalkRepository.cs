using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVPConf.Backend.Domain;

namespace MVPConf.Backend.Repository.Contract
{
    public interface ITalkRepository
    {
        Task Save(Talk talk);

        Task Save(List<Talk> talks);

        Task<Talk> GetTalkById(int id);

        Task<List<Talk>> GetTalks();
    }
}
