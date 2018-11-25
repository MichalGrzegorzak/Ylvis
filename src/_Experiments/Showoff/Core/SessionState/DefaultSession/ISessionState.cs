namespace Showoff.Core.Features.SessionState.DefaultSession
{
    public interface ISessionState
    {
        void Clear();
        void Delete(string key);
        object Get(string key);
        void Store(string key, object value);
    }
}