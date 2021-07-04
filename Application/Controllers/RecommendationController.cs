using Library.Models.Requests;
using Library.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.AnswerSetManagement;
using Services.RecommendationManagement;
using Services.SessionManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class RecommendationController : BaseController
    {
        private readonly IAnswerSetManager _answerSetManager;
        private readonly IRecommendationManager _recommendationManager;
        public RecommendationController(ISessionManager sessionManager, IAnswerSetManager answerSetManager, IRecommendationManager recommendationManager) : base(sessionManager)
        {
            _answerSetManager = answerSetManager;
            _recommendationManager = recommendationManager;
        }

        [HttpPost]
        public async Task<JsonResult> GetRecommendation([FromBody] CourseRecommendationRequest request)
        {
            try
            {
                var sessionID = request?.SessionID ?? 0;

                if (sessionID < 1)
                    sessionID = await _answerSetManager.SaveSessionAnswers();

                if (sessionID < 1)
                    return new JsonResult(new { success = false, message = "Failed to get recommendation." });

                var course = await _recommendationManager.RecommendCourse(sessionID);
                var viewModel = new CourseRecommendationResponse(sessionID, course);

                return new JsonResult(new { success = true, data = viewModel });

            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to get recommendation." });
            }
        }
    }
}
