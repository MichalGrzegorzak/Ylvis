using System;
using System.Runtime.Serialization;

namespace Showoff.Notices.BusinessLogic.Dto
{
    [DataContract(Namespace = "http://www.fnc.com/xmlns/prod/cms/services/funeralnotices/updatemethod")]
    public class FuneralNoticeEntityDto : IFuneralNoticeEntityDto
    {
        [DataMember]
        public Int64 Id { get; set; }
        [DataMember]
        public Int64 MemorialId { get; set; }
        
        [DataMember]
        public string ParentBranchId { get; set; }
        [DataMember]
        public string CedarCode { get; set; }
        [DataMember]
        public string BranchId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string KnownAs { get; set; }
        [DataMember]
        public DateTime DateOfDeath { get; set; }

        [DataMember]
        public DateTime? DateOfFuneral { get; set; }
        [DataMember]
        public string Obituary { get; set; }
        [DataMember]
        public string OnlineMemorialUrl { get; set; }
        [DataMember]
        public string DeceasedImageUrl { get; set; }
        [DataMember]
        public bool ShowDeceasedImage { get; set; }
        [DataMember]
        public bool RemoveNotice { get; set; }
        [DataMember]
        public string Source { get; set; } 
    }
}