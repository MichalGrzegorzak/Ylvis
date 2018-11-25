using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Find;
using Showoff.Notices.DAL.Enums;
using Newtonsoft.Json;

namespace Showoff.Notices.DAL.Entities
{
    public abstract class FuneralNoticeBase
    {
        public Int64 Id { get; set; }

        [JsonIgnore]
        public Int64 MemorialId { get; set; }

        [JsonIgnore]
        public string CedarCode { get; set; }

        [JsonIgnore]
        public string BranchId { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }

        [JsonIgnore]
        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public string KnownAs { get; set; }

        [JsonIgnore]
        public string OnlineMemorialUrl { get; set; }

        [JsonIgnore]
        public string DeceasedImageUrl { get; set; }

        public string ParentBranchId { get; set; }

        public string Surname { get; set; }

        public string FirstNames { get; set; }

        public DateTime DateOfDeath { get; set; }

        public DateTime? DateOfFuneral { get; set; }

        public string Obituary { get; set; }

        //enum hacking
        public SourceType Source { get; set; }
        public virtual string SourceString
        {
            get { return Source.ToString(); }
            set
            {
                SourceType newValue;
                if (Enum.TryParse(value, out newValue))
                    Source = newValue;
            }
        }

        public NoticeState NoticeState { get; set; }
        public virtual string NoticeStateString
        {
            get { return NoticeState.ToString(); }
            set
            {
                NoticeState newValue;
                if (Enum.TryParse(value, out newValue))
                    NoticeState = newValue;
            }
        }
        

        public bool ShowDeceasedImage { get; set; }

        public bool RemoveNotice { get; set; }

        public bool IsOnlineMemorial()
        {
            return !(string.IsNullOrEmpty(OnlineMemorialUrl));
        }


        //public virtual ICollection<AuditFuneralNotice> AuditLogFuneralNotices { get; set; } //lazy loaded
    }
}
