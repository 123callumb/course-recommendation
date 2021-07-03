using Microsoft.AspNetCore.Mvc;
using Services.SessionManagement;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISessionManager sessionManager) : base(sessionManager)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
