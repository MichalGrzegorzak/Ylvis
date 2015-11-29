using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;

namespace Showoff.Integration.Tests.FuneralNotices.Helpers
{
    public class FuneraNoticeBuilder
    {
        private Int64 Id = 0;
        private Int64 MemorialId = 0;
        private string ParentBranchId = string.Empty;

        //private DateTime CreateDate = DateTime.UtcNow;
        private DateTime ModifiedDate = DateTime.UtcNow;
        private DateTime DateOfDeath = DateTime.Today;
        private DateTime DateOfFuneral = DateTime.Today;

        private string KnownAs = string.Empty;
        private string OnlineMemorialUrl = "www.OnlineMemorial.url";
        private string DeceasedImageUrl = "www.DeceasedImage.url";

        private string Obituary = "ObituaryObituary";

        private string Surname = "Test";
        private string FirstNames = "John";
        private SourceType Source = SourceType.RAINBOW;

        public FuneralNotice Build()
        {
            var notice = new FuneralNotice(Id, FirstNames, Surname)
            {
                MemorialId = MemorialId,
                ParentBranchId = ParentBranchId,
                Source = Source,
                Obituary = Obituary,
                KnownAs = KnownAs,
                OnlineMemorialUrl = OnlineMemorialUrl,
                DeceasedImageUrl = DeceasedImageUrl,
                DateOfDeath = DateOfDeath,
                DateOfFuneral = DateOfFuneral,
                ModifiedDate = ModifiedDate
            };

            return notice;
        }
        public FuneraNoticeBuilder WithId(Int64 id)
        {
            this.Id = id;
            return this;
        }
        public FuneraNoticeBuilder WithFirstName(string firstnames)
        {
            this.FirstNames = firstnames;
            return this;
        }
        public FuneraNoticeBuilder WithSurname(string lastname)
        {
            this.Surname = lastname;
            return this;
        }
        public FuneraNoticeBuilder WithDateOfFunerale(DateTime date)
        {
            this.DateOfFuneral = date;
            return this;
        }
        public FuneraNoticeBuilder WithDateOfDeath(DateTime date)
        {
            this.DateOfDeath = date;
            return this;
        }
        public FuneraNoticeBuilder WithSourceType(SourceType source)
        {
            this.Source = source;
            return this;
        }

        public static implicit operator FuneralNotice(FuneraNoticeBuilder instance)
        {
            return instance.Build();
        }
    }
}
