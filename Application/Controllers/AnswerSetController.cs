using Library.Models.AnswerSet.Requests;
using Microsoft.AspNetCore.Mvc;
using Services.AnswerSetManagement;
using Services.SessionManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class AnswerSetController : BaseController
    {
        private readonly IAnswerSetManager _answerSetManager;
        public AnswerSetController(ISessionManager sessionManager, IAnswerSetManager answerSetManager) : base(sessionManager)
        {
            _answerSetManager = answerSetManager;
        }

        public async Task<JsonResult> RegisterSessionAnswer([FromBody]AnswerSetRequest request)
        {
            try
            {
                return new JsonResult(new { success = true });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to save session answer" });
            }
        }
    }
}
