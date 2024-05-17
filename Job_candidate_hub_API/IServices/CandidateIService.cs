using Models;

namespace Job_candidate_hub_API.IServices
{
    public interface CandidateIService
    {
        public string AddOrUpdateCandidate(CandidateModel model);
    }
}
