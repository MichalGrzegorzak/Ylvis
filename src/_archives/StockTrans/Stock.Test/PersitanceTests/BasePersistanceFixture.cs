#region license
// Copyright (c) 2005 - 2007 Ayende Rahien (ayende@ayende.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Ayende Rahien nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using NHibernate;
using MbUnit.Framework;
using NHibernate.Tool.hbm2ddl;
using Rhino.Commons.NHibernate;
using Rhino.Commons.ForTesting;
using Rhino.Commons.Util;
using Stock.Core;
using Stock.Core.Domain;

namespace Stock.Test
{
    //[TestFixture]
    public class BasePersistanceFixture : DatabaseTestFixtureBase
    {
        [TestFixtureSetUp]
        public void OneTimeTestInitialize()
        {
            EnableNhibernateLogging();
            //turn on log4net logging (and supress output to console)

            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();

            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"config\Windsor.config"));

            IntializeNHibernateAndIoC(PersistenceFramework.NHibernate,
                                      path,
                                      DatabaseEngine.SQLite,
                                      "",
                                      MappingInfo.FromAssemblyContaining<Employee>());
        }

        const string TransactionLog = "NHibernate.Transaction.AdoTransaction";

        [SetUp]
        public void TestInitialize()
        {
             CurrentContext.CreateUnitOfWork();
        }


        [TearDown]
        public void TestCleanup()
        {
            //Cleanup the top level UnitOfWork
            CurrentContext.DisposeUnitOfWork();
        }

        private static void EnableNhibernateLogging()
        {
            IAppender fileApp = null;
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            foreach (IAppender app in hierarchy.Root.Appenders)
            {
                if (app is RollingFileAppender)
                //&& app.Name == "nHibernateAppender")
                {
                    fileApp = app;
                }
            }

            //turn on log4net logging (and supress output to console)
            BasicConfigurator.Configure(fileApp);
        }
    }
}