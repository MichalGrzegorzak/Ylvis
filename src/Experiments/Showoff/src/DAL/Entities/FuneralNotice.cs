using System;
using System.Collections.Generic;

using EPiServer.Find;
using Showoff.Notices.BusinessLogic.Dto;
using Showoff.Notices.DAL.Enums;
using Newtonsoft.Json;

namespace Showoff.Notices.DAL.Entities
{
    public class FuneralNotice : FuneralNoticeBase
    {
        public FuneralNotice() //required by EF
        {
            ShowDeceasedImage = true; //default value
            CreateDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
            NoticeState = NoticeState.None;
        }
        public FuneralNotice(Int64 id, string firstNames, string surname)
            : this()
        {
            Id = id;
            FirstNames = firstNames;
            Surname = surname;
        }

        public FuneralNotice(IFuneralNoticeEntityDto message) : this()
        {
            Id = message.Id;
            MemorialId = message.MemorialId;
            ParentBranchId = message.ParentBranchId;
            CedarCode = message.CedarCode;
            BranchId = message.BranchId;
            Surname = message.Surname;
            FirstNames = message.FirstName;
            KnownAs = message.KnownAs;
            DateOfDeath = message.DateOfDeath;
            DateOfFuneral = message.DateOfFuneral;
            Obituary = message.Obituary;
            OnlineMemorialUrl = message.OnlineMemorialUrl;
            DeceasedImageUrl = message.DeceasedImageUrl;
            ShowDeceasedImage = message.ShowDeceasedImage;
            RemoveNotice = message.RemoveNotice;
            SourceType source;
            SourceType.TryParse(message.Source, out source);
            Source = source;
        }

    }

}