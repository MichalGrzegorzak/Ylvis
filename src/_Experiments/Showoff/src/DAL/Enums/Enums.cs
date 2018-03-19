using System;
using System.Runtime.Serialization;

namespace Showoff.Notices.DAL.Enums
{
    [Serializable]
    public enum SourceType
    {
        RAINBOW = 0,
        PERMAVITA = 1
    }
    
    [Serializable]
    public enum NoticeState
    {
        None = -1,
        Created = 0,
        Updated = 1,
        Deleted = 2
    }

    [Serializable]
    public enum AuditState
    {
        Unknown = 0,
        Creating = 1,
        Updateing = 2,
        Validated = 3,
        SavedToDb = 4,
        Indexed = 5,
        Deleting = 6,
        ValidationFailed = -1,
        DbError = -2,
        IndexingFailed = -3,
        EmptyIdPermavita = -4
    }
}
