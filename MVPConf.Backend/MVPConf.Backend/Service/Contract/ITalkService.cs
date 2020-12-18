using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVPConf.Backend.Model;
using MVPConf.Backend.Model.Response;

namespace MVPConf.Backend.Service.Contract
{
    public interface ITalkService
    {
        Task<List<TalkResponse>> GetTalks();

        Task<TalkResponse> GetTalkById(int id);

        Task AddTalks(List<TalkRequest> talksRequest);
    }
}
