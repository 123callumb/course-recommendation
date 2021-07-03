using Library.Models.Session;
using Microsoft.AspNetCore.Mvc;
using Services.SessionManagement;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public BaseController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        protected async Task<UserSession> GetUserSession()
        {
            return await _sessionManager.GetOrSetSession();
        }
    }
}
