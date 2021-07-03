using Microsoft.AspNetCore.Mvc;
using Services.QuestionManagement;
using Services.SessionManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionManager _questionManager;
        public QuestionController(IQuestionManager questionManager, ISessionManager sessionManager) : base(sessionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        public async Task<JsonResult> LoadAll()
        {
            try
            {
                var questions = await _questionManager.LoadAll();
                var existingSessionAnswers = await GetUserSession();
                return new JsonResult(new { success = true, data = questions });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to load questions." });
            }
        }
    }
}
