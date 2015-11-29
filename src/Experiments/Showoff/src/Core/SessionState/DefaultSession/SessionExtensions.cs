namespace Showoff.Core.Features.SessionState.DefaultSession
{
    public static class SessionExtensions
    {
        public static T Get<T>(this ISessionState sessionState, string key) where T : class
        {
            return sessionState.Get(key) as T;
        }
    }
}