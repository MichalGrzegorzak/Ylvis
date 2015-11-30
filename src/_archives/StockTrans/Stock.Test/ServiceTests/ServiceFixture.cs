using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Commons;
using MbUnit.Framework;
using Rhino.Commons;
using Rhino.Commons.NHibernate;
using Stock.Core.Controller;
using Stock.Core.Domain;
using NHibernate.Exceptions;
using NHibernate.Linq;
using System.Linq;
using System.Linq.Dynamic;
using Stock.Test.ServiceReference1;
using linqExpression = System.Linq.Expressions;

namespace Stock.Test.ServiceTests
{
    [TestFixture]
    public class ServiceFixture 
    {
        private ITestService1 _service = null;

        [Test]
        public void CanConnect()
        {
            bool res = InitializeService();   
            Assert.IsTrue(res);
        }

        public bool InitializeService()
        {
            _service = new TestService1Client("WSHttpBinding_ITestService1");
            
            string s = _service.GetData(1);
            if(!String.IsNullOrEmpty(s))
                return true;

            return false;
        }

    }
}
