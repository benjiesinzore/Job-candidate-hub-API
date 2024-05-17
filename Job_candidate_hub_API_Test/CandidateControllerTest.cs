using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Job_candidate_hub_API;
using Job_candidate_hub_API.IServices;
using Job_candidate_hub_API.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using Job_candidate_hub_API.Controllers;
using Microsoft.Extensions.Logging;
using Job_candidate_hub_API.Routes;
using FakeItEasy;

namespace Job_candidate_hub_API_Test
{
    public class CandidateControllerTest
    {

        private readonly CandidateRoutes implService = new CandidateRoutes();


        private readonly Mock<CandidateRoutes> _candidateServiceMock;
        private readonly Mock<ILogger<CandidateController>> _loggerMock;
        private readonly CandidateController _controller;

        public CandidateControllerTest()
        {
            _candidateServiceMock = new Mock<CandidateRoutes>();
            _loggerMock = new Mock<ILogger<CandidateController>>();
            _controller = new CandidateController(_loggerMock.Object, _candidateServiceMock.Object);
        }




        [Fact]
        public void AddOrUpdateCandidate_ReturnsOkResult_WhenSuccessful()
        {
            //Arrange
            var candidate = A.Fake<CandidateModel>();

            // Act
            var okResult = _controller.AddOrUpdateCandidate(candidate);

            // Assert
            Assert.IsType<ActionResult<GlobalResponseModel>>(okResult);
            var okObjectResult = Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.Equal(200, okObjectResult.StatusCode);


        }
    }
}