using System.IO;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using Showoff.Core.Features.SessionState;
using Showoff.Core.Features.SessionState.DefaultSession;
using Showoff.Notices.BusinessLogic.EpiFind;
using Showoff.Notices.DAL.Context;
using Showoff.Web.Core.Features.Wcs;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace Showoff.Notices.Initialize
{
	public class NoticesRegistry : Registry
	{
		public NoticesRegistry()
		{
            Scan(x =>
            {
                x.WithDefaultConventions();
                x.AssemblyContainingType<NoticesIndexer>();
            });

            //session
            For<HttpSessionStateBase>().Use(ctx => new HttpSessionStateWrapper(HttpContext.Current.Session));
            For<ISessionState>().Use<DefaultSessionState>();
            
            For<ISessionDataProvider<ProductConfigSessionData>>()
                .HybridHttpOrThreadLocalScoped()
                .Use<SessionDataProvider<ProductConfigSessionData>>();

            //HttpContext.Current = MockHelper.FakeHttpContext();
		}
	}

    public static class MockHelper
    {
        public static HttpContext FakeHttpContext()
        {
            var httpRequest = new HttpRequest("", "http://stackoverflow/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                    new HttpStaticObjectsCollection(), 10, true,
                                                    HttpCookieMode.AutoDetect,
                                                    SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                        BindingFlags.NonPublic | BindingFlags.Instance,
                                        null, CallingConventions.Standard,
                                        new[] { typeof(HttpSessionStateContainer) },
                                        null)
                                .Invoke(new object[] { sessionContainer });

            return httpContext;
        }
    }
}
