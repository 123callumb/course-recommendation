using Microsoft.AspNetCore.Mvc;
using Services.AnswerSetManagement;
using Services.SessionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class RecommendationController : BaseController
    {
        private readonly IAnswerSetManager _answerSetManager;
        public RecommendationController(ISessionManager sessionManager, IAnswerSetManager answerSetManager) : base(sessionManager)
        {
            _answerSetManager = answerSetManager;
        }

        [HttpGet]
        public async Task<JsonResult> GetRecommendation()
        {
            try
            {
                return new JsonResult(new { success = true });

            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to get recommendation" });
            }
        }
    }
}
