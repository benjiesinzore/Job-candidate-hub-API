using Job_candidate_hub_API.IServices;
using Libs;
using Models;

namespace Job_candidate_hub_API.Services
{
    public class CandidateService : CandidateIService
    {

        public string AddOrUpdateCandidate(CandidateModel model)
        {

            var res = SystemTools.AddOrUpdateCandidate(model);
            return res;


        }
    }
}
