using Library.Models.Session;
using Microsoft.AspNetCore.Mvc;
using Services.SessionManagement;

namespace Application.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public BaseController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        protected UnsavedUserSession GetUserSession()
        {
            return _sessionManager.GetOrSetSession();
        }
    }
}
