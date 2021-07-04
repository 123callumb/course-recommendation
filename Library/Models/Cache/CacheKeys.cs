namespace Library.Models.Cache
{
    public static class CacheKeys
    {
        public static string UserSession(string sessionCode) => $"user_session_${sessionCode}";
        public static string AllSessionCodes => "all_user_sessions";
    }
}
