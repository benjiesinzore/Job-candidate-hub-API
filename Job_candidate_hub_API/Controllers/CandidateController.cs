using Job_candidate_hub_API.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Job_candidate_hub_API.Controllers
{
    /// <summary>
    /// CandidateController Class 
    /// </summary>
    [ApiController]
    [Route("[controller]/api/")]
    public class CandidateController : Controller
    {
        private readonly CandidateRoutes candidateRoute = new CandidateRoutes();

        private readonly ILogger<CandidateController> logger;

        /// <summary>
        /// CandidateController Constractor
        /// </summary>
        public CandidateController(ILogger<CandidateController> logger)
        {
            this.logger = logger;
        }


        /// <summary>
        /// This endpoint accespts, FirstName, LastName, Email, Phone, CallTimeInterval, LinkedinUrl, GithubUrl and Comment.
        /// If the Candidate already exist the details are updated and returns a message indicating the same, this is also true for when a new candidates profile is added.
        /// </summary>
        /// <respone code="200">Returns success if the data is added or updated</respone>
        [AllowAnonymous]
        [HttpPut("addupdate")]
        [Produces("application/json")]
        public ActionResult<string> AddOrUpdateCandidate([FromBody] CandidateModel userModel)
        {

            try
            {
                var loginResponse = new GlobalResponseModel<string>
                {

                    Status = 200,
                    Message = "Success",
                    Error = null,
                    Data = candidateRoute.AddOrUpdateCandidate(userModel)
                };



                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                var loginResponse = new GlobalResponseModel<string>
                {

                    Status = 500,
                    Message = "An error occured.",
                    Error = ex.Message,
                    Data = null
                };

                string message = ParamsModel.FailLogin + ": " + ex.Message;
                logger.LogError(message);

                return StatusCode(500, loginResponse);

            }


        }
    }
}
