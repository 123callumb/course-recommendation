using Library.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Services.AnswerSetManagement;
using Services.SessionManagement;
using System;

namespace Application.Controllers
{
    public class AnswerSetController : BaseController
    {
        private readonly IAnswerSetManager _answerSetManager;
        public AnswerSetController(ISessionManager sessionManager, IAnswerSetManager answerSetManager) : base(sessionManager)
        {
            _answerSetManager = answerSetManager;
        }

        [HttpPost]
        public JsonResult RegisterSessionAnswer([FromBody]AnswerSetRequest request)
        {
            try
            {
                if (request.SectionID == 0 || request.AnswerID == 0 || request.GroupID == 0)
                    return new JsonResult(new { success = false, message = "Answer, section and group id cannot be null" });

                _answerSetManager.SetAnswerSet(request.GroupID, request.SectionID, request.AnswerID, request.QuestionID);
                return new JsonResult(new { success = true });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to save session answer" });
            }
        }
    }
}
