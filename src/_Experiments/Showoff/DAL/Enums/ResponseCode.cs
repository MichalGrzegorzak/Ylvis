namespace Showoff.Notices.DAL.Enums
{
    public enum ResponseCode
    {
        Success = 0,
        ValidationFailed = 100,
        DatabaseError = 200,
        EpiFindError = 300,
        UncatchedException = 400
    }
}
