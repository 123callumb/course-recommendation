using Library.Models.Session;
using System.Threading.Tasks;

namespace Services.SessionManagement
{
    public interface ISessionManager
    {
        Task<UserSession> GetOrSetSession();
    }
}
