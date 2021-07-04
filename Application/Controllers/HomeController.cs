using Microsoft.AspNetCore.Mvc;
using Services.QuestionManagement;
using Services.SessionManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IQuestionManager _questionManager;
        public HomeController(ISessionManager sessionManager, IQuestionManager questionManager) : base(sessionManager)
        {
            _questionManager = questionManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Load()
        {
            try
            {
                var questions = await _questionManager.LoadAll();
                var existingSessionAnswers = GetUserSession();
                return new JsonResult(new { success = true, data = questions });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to load questions." });
            }
        }
    }
}
