using Library.Models.Session;

namespace Services.SessionManagement
{
    public interface ISessionManager
    {
        UnsavedUserSession GetOrSetSession();
        string GetUserSessionCode();
    }
}
