using Microsoft.AspNetCore.Mvc;
using Services.QuestionManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionManager _questionManager;
        public QuestionController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        public async Task<JsonResult> LoadAll()
        {
            try
            {
                var questions = await _questionManager.LoadAll();
                return new JsonResult(new { success = true, data = questions });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to load questions." });
            }
        }
    }
}
