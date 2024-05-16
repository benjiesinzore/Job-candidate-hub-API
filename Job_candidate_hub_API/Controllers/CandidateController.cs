using Microsoft.AspNetCore.Mvc;

namespace Job_candidate_hub_API.Controllers
{
    public class CandidateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
