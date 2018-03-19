using System;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using Showoff.Notices.BusinessLogic.Helpers;
using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;
using Newtonsoft.Json;

namespace Showoff.Notices.BusinessLogic.Logging
{
    public interface INoticeLogger
    {
        void Dispose();
        void Log(FuneralNotice notice, AuditState newState, string error = null);
        void Log(FuneralNotice notice, Exception exception);
        void FlushToDb();
        bool CanLogToElmah(AuditState state);
        bool CanLogToDB(AuditState state);
    }

    public class NoticeLogger : IDisposable, INoticeLogger
    {
        private readonly NoticesContext _ctx = null;
        private AuditFuneralNotice _lastAudit;
        private LoggerConfiguration _config = LoggerConfiguration.Inst;

        public NoticeLogger()
        {
            _ctx = _ctx ?? new NoticesContext();
        }
        public NoticeLogger(NoticesContext ctx) : this()
        {
            _ctx = ctx;
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (_ctx != null)
                {
                    _ctx.SaveChanges();
                    _ctx.Dispose();
                }
                GC.SuppressFinalize(this);
            }
        }
        public void Dispose()
        {
            Dispose(false);
        }

        private FuneralNotice CreateEmptyNotice()
        {
            var notice = new FuneralNotice();
            notice.Id = -1;
            notice.DateOfDeath = DateTime.UtcNow;
            notice.DateOfFuneral = DateTime.UtcNow;
            return notice;
        }

        public void Log(FuneralNotice notice, AuditState newState, string error = null)
        {
            notice = notice ?? CreateEmptyNotice(); 
            var audit = new AuditFuneralNotice(notice, newState) {Error = error};

            if (CanLogToDB(newState))
            {
                AddAuditNotice(audit);
            }

            if (error == null) //there is no exception
            {
                if (CanLogToElmah(newState))
                {
                    string json = JsonConvert.SerializeObject(audit, Formatting.Indented);
                    new Exception(json).LogToElmah();
                }
            }

            _lastAudit = audit;
        }
        public void Log(FuneralNotice notice, Exception exception)
        {
            var state = GetFromExceptionType(exception);
            string errorMessage = exception.Message;
            Log(notice, state, errorMessage);

            if (CanLogToElmah(state))
            {
                exception.LogToElmah();
            }
        }

        private AuditState GetFromExceptionType(Exception exception)
        {
            if (exception is DbEntityValidationException) return AuditState.ValidationFailed;
            if (exception is SqlException) return AuditState.DbError;
            if (exception is EpiFindException) return AuditState.IndexingFailed;
            return AuditState.Unknown;
        }

        private void AddAuditNotice(AuditFuneralNotice audit)
        {
            //prevent adding the same message twice
            if (!IsSameAsLastAuditNotice(audit))
                _ctx.AuditLogFuneralNotices.Add(audit);

            //_ctx.SaveChanges(); -> performance
        }

        private bool IsSameAsLastAuditNotice(AuditFuneralNotice audit)
        {
            if (audit.Equals(_lastAudit))
                return true;

            var lastDbAudit = _ctx.AuditLogFuneralNotices.GetLast(audit.FuneraNoticeId);
            if (audit.Equals(lastDbAudit))
                return true;

            return false;
        }

        public void FlushToDb()
        {
            _ctx.SaveChanges();
        }

        public bool CanLogToElmah(AuditState state)
        {
            if (_config.IsElmahLoggingEnabled)
                if (_config.StatesForElmah.Contains(state))
                return true;

            return false;
        }

        public bool CanLogToDB(AuditState state)
        {
            if (_config.IsDbLoggingEnabled)
                if (_config.StatesForDbAudit.Contains(state))
                return true;

            return false;
        }

    }
}
