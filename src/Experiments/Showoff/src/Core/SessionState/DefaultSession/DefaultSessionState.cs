using System.Web;

namespace Showoff.Core.Features.SessionState.DefaultSession
{
    public class DefaultSessionState : ISessionState
    {
        private readonly HttpSessionStateBase session;

        public DefaultSessionState(HttpSessionStateBase session)
        {
            this.session = session;
        }

        public void Clear()
        {
            session.RemoveAll();
        }

        public void Delete(string key)
        {
            session.Remove(key);
        }

        public object Get(string key)
        {
            return session[key];
        }

        public void Store(string key, object value)
        {
            session[key] = value;
        }
    }
}
