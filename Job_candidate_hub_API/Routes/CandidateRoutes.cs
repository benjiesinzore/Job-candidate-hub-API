using Job_candidate_hub_API.IServices;
using Job_candidate_hub_API.Services;
using Models;

namespace Job_candidate_hub_API.Routes
{
    public class CandidateRoutes
    {
        CandidateIService implService = new CandidateService();
        public string AddOrUpdateCandidate(CandidateModel model)
        {
            return "Candidate added or updated successfully";
            //return implService.AddOrUpdateCandidate(model);
        }
    }
}
