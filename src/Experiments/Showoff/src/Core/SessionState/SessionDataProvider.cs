using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showoff.Core.Features.SessionState.DefaultSession;

namespace Showoff.Core.Features.SessionState
{
    public interface ISessionData
    {
        void Clear();
    }

    public interface ISessionDataProvider<T> where T : class, ISessionData, new()
    {
        T Data { get; set; }
        void Save();
        void Clear();
    }

    public class SessionDataProvider<T> : ISessionDataProvider<T> where T : class, ISessionData, new()
    {
        private readonly ISessionState session;
        private string key;
        public T Data { get; set; }

        public SessionDataProvider(ISessionState session)
        {
            this.session = session;
            key = typeof(T).Name;
            Data = session.Get<T>(key) ?? new T();
        }

        public void Save()
        {
            session.Store(key, Data);
        }

        public void Clear()
        {
            Data.Clear();
            Save();
        }
    }

}
