using Library.Models.AnswerSet.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class AnswerSetController : Controller
    {
        public AnswerSetController()
        {

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
