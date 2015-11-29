using System;

using EPiServer.Find;
using EPiServer.Find.Api;
using Showoff.Notices.BusinessLogic.Logging;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;

namespace Showoff.Notices.BusinessLogic.EpiFind
{
    public class EpiFindNotice  //, IContentData
    {
        /// <summary>
        /// For EpiFind only
        /// </summary>
        public EpiFindNotice()
        {
        }

        public EpiFindNotice(FuneralNotice notice) : this()
        {
            Id = notice.Id;
            IsOnlineMemorial = notice.IsOnlineMemorial();
            //json ignore
            //MemorialId = notice.MemorialId;
            //BranchId = notice.BranchId;
            //KnownAs = notice.KnownAs;
            CedarCode = notice.CedarCode;
            OnlineMemorialUrl = notice.OnlineMemorialUrl;
            DeceasedImageUrl = notice.DeceasedImageUrl;
            ParentBranchId = notice.ParentBranchId;
            Surname = notice.Surname;
            FirstNames = notice.FirstNames;
            DateOfDeath = notice.DateOfDeath;
            DateOfFuneral = notice.DateOfFuneral;
            Obituary = notice.Obituary;
            
            ShowDeceasedImage = notice.ShowDeceasedImage;
            RemoveNotice = notice.RemoveNotice;
            this.Source = notice.Source;
            this.NoticeState = notice.NoticeState;
            
            DayOfDeath = DateOfDeath.Day;
            MonthOfDeath = DateOfDeath.Month;
            YearOfDeath = DateOfDeath.Year;

            if (!IsOnlineMemorial)
            {
                TimeToLive = LoggerConfiguration.Inst.NoticesTimeToLeave;
            }
        }

        //[JsonIgnore]public Int64 MemorialId { get; set; }
        //[JsonIgnore]public string BranchId { get; set; }
        //[JsonIgnore]public DateTime CreateDate { get; set; }
        //[JsonIgnore]public DateTime ModifiedDate { get; set; }
        //[JsonIgnore]public string KnownAs { get; set; }
        public string OnlineMemorialUrl { get; set; }
        public string DeceasedImageUrl { get; set; }

        [Id]
        public Int64 Id { get; set; }
        public string ParentBranchId { get; set; }
        public string CedarCode { get; set; }
        public string Surname { get; set; }
        public string FirstSurnameLetter
        {
            get
            {
                return (string.IsNullOrEmpty(this.Surname) ? (char)0 : this.Surname[0]).ToString().ToUpperInvariant();
            }
        }
        public string FirstNames { get; set; }
        public DateTime DateOfDeath { get; set; }
        public DateTime? DateOfFuneral { get; set; }
        public string Obituary { get; set; }
        public SourceType Source { get; set; }
        public NoticeState NoticeState { get; set; }
        public bool ShowDeceasedImage { get; set; }
        public bool RemoveNotice { get; set; }
        public bool IsOnlineMemorial { get; set; }

        //NEW PROPERTIES
        public int DayOfDeath { get; set; }
        public int MonthOfDeath { get; set; }
        public int YearOfDeath { get; set; }

        [TimeToLive]
        public TimeToLive TimeToLive { get; set; }
    }
}
