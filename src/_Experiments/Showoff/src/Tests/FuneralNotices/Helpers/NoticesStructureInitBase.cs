using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using Showoff.Core.Features.Extensions;
using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;
using Showoff.Notices.Initialize;
using NUnit.Framework;
using StructureMap;

namespace Showoff.Integration.Tests.FuneralNotices.Helpers
{
    public class NoticesStructureInitBase
    {
        [TestFixtureSetUp]
        public virtual void Init()
        {
            ObjectFactory.Initialize(
                x => x.AddRegistry(new NoticesRegistry())
                );
        }

    }
}
