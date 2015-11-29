using System;
using Showoff.Notices.DAL.Enums;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;

namespace Showoff.Notices.DAL.Entities
{
    public class AuditFuneralNotice : FuneralNoticeBase
    {
        public AuditFuneralNotice() //required by EF
        {
            Entry = DateTime.UtcNow;
            //AuditState = AuditState.Creating;
            CreateDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
            NoticeState = NoticeState.None;
        }

        public AuditFuneralNotice(FuneralNotice notice, AuditState newState) : this()
        {
            if (notice.Id == 0)
            {
                if(newState != AuditState.Creating && newState != AuditState.EmptyIdPermavita)
                {
                    throw new Exception("Sanity check. Notice ID=0, but state is: " + newState);
                }
            }

            this.FuneraNoticeId = notice.Id;
            this.MemorialId = notice.MemorialId;
            this.CedarCode = notice.CedarCode;
            this.BranchId = notice.BranchId;
            this.CreateDate = notice.CreateDate;
            this.ModifiedDate = notice.ModifiedDate;
            this.KnownAs = notice.KnownAs;
            this.OnlineMemorialUrl = notice.OnlineMemorialUrl;
            this.DeceasedImageUrl = notice.DeceasedImageUrl;
            this.ParentBranchId = notice.ParentBranchId;
            this.Surname = notice.Surname;
            this.FirstNames = notice.FirstNames;
            this.DateOfDeath = notice.DateOfDeath;
            this.DateOfFuneral = notice.DateOfFuneral;
            this.Obituary = notice.Obituary;
            this.Source = notice.Source;
            this.ShowDeceasedImage = notice.ShowDeceasedImage;
            this.RemoveNotice = notice.RemoveNotice;

            AuditState = newState;
        }

        public override bool Equals(object obj)
        {
            var audit = obj as AuditFuneralNotice;
            if (audit == null)
                return false;

            if (audit.AuditState == AuditState
                && audit.FuneraNoticeId == FuneraNoticeId)
                return true;

            return false;
        }

        public new Int64 Id { get; set; }

        public Int64 FuneraNoticeId { get; set; }
        public virtual FuneralNotice FuneralNotice { get; set; }
        public DateTime Entry { get; set; }
        

        //enums hacking
        public AuditState AuditState { get; set; }
        public virtual string AuditStateString
        {
            get { return AuditState.ToString(); }
            set
            {
                AuditState newValue;
                if (Enum.TryParse(value, out newValue))
                    AuditState = newValue;
            }
        }

        public string Error { get; set; }

    }
}