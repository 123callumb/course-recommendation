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

        [HttpGet]
        public async Task<JsonResult> GetRecommendation()
        {
            try
            {
                int sessionID = await _answerSetManager.SaveSessionAnswers();

                if(sessionID < 1)
                    return new JsonResult(new { success = false, message = "Failed to get recommendation." });

                var course = await _recommendationManager.RecommendCourse(sessionID);

                return new JsonResult(new { success = true, data = course });

            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to get recommendation." });
            }
        }
    }
}
