using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Showoff.Core.Features.SessionState;
using Showoff.Core.Features.SessionState.DefaultSession;
using Showoff.Web.Core.Features.Wcs;
using Moq;
using NUnit.Framework;
using StructureMap;
using IContainer = StructureMap.IContainer;

namespace Showoff.Web.Tests.Core.Products
{
    [TestFixture]
    public class MaintainProductConfigurationTests
    {
        private readonly IContainer _container;
        private readonly Dictionary<string, object> _sessionStore = new Dictionary<string, object>();

        public MaintainProductConfigurationTests()
        {
            var mockSession = new Mock<ISessionState>();
            mockSession.Setup(x => x.Store(It.IsAny<string>(), It.IsAny<object>())).Callback<string, object>(
                    (x, y) => _sessionStore[x] = y);

            mockSession.Setup(x => x.Get(It.IsAny<string>())).Returns<string>(x => 
            {
                object result = null;
                _sessionStore.TryGetValue(x, out result);
                return result;
            });

            var provider = new SessionDataProvider<ProductConfigSessionData>(mockSession.Object);
            
            _container = new Container();
            _container.Configure(x => x.For<ISessionDataProvider<ProductConfigSessionData>>().Use(() => provider));
        }

        #region Helpers

        private ISessionDataProvider<ProductConfigSessionData> GetSessionProvider()
        {
            return _container.GetInstance<ISessionDataProvider<ProductConfigSessionData>>();
        }

        private void PrePopulateSession(Dictionary<string, string> dict = null)
        {
            dict = dict ?? new Dictionary<string, string>
            {
                {"storeId", "2"},
                {"URL", "http://www.wp.pl"}
            };

            var data = new ProductConfigSessionData();
            data.Configuration = dict;

            var provider = GetSessionProvider();
            provider.Data = data;
            provider.Save();
        }

        #endregion


        [Test]
        public void t01_verify_saving_in_session()
        {
            var provider = GetSessionProvider();
            provider.Data.Online.storeId = "22";
            provider.Data.Online.URL = "http://www.wp.pl";
            provider.Save();

            string key = typeof(ProductConfigSessionData).Name;
            var data = _sessionStore[key] as ProductConfigSessionData;

            Assert.That(data.Configuration["storeId"], Is.EqualTo("22"));
            Assert.That(data.Configuration["URL"], Is.EqualTo("http://www.wp.pl"));
        }

        [Test]
        public void t02_verify_that_can_read_data_from_session()
        {
            PrePopulateSession();

            var provider = GetSessionProvider();

            Assert.That(provider.Data.Online.storeId, Is.EqualTo("2"));
            Assert.That(provider.Data.Online.URL, Is.EqualTo("http://www.wp.pl"));
        }

    }
}
