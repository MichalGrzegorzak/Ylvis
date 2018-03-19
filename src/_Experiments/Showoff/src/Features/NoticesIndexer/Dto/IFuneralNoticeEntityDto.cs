using System;

namespace Showoff.Notices.BusinessLogic.Dto
{
    public interface IFuneralNoticeEntityDto
    {
        Int64 Id { get; set; }
        Int64 MemorialId { get; set; }
        string ParentBranchId { get; set; }
        string CedarCode { get; set; }
        string BranchId { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        string KnownAs { get; set; }
        DateTime DateOfDeath { get; set; }
        DateTime? DateOfFuneral { get; set; }
        string Obituary { get; set; }
        string OnlineMemorialUrl { get; set; }
        string DeceasedImageUrl { get; set; }
        bool ShowDeceasedImage { get; set; }
        bool RemoveNotice { get; set; }
        string Source { get; set; }
    }
}