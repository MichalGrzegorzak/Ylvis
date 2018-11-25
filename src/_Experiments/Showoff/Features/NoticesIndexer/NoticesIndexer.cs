using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using EPiServer.Find;
using Showoff.Core.Features.Extensions;
using Showoff.Notices.BusinessLogic.Helpers;
using Showoff.Notices.BusinessLogic.Logging;
using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;
using Filters = EPiServer.Find.Filters;

namespace Showoff.Notices.BusinessLogic.EpiFind
{
    public class NoticesIndexer : INoticesIndexer
    {
        private readonly INoticeLogger _logger;
        private readonly LoggerConfiguration _config = LoggerConfiguration.Inst;
        private static IClient _client;
        public IClient NoticeClient { get { return _client; } }

        #region .ctor
		public NoticesIndexer(INoticeLogger logger)
        {
            _logger = logger ?? new NoticeLogger();

            if (_client == null)
            {
                CreateClients(null);
            }
            GetFilter = new FilterBuilder<EpiFindNotice>(_client);
        }

        public void CreateClients(IClient clientNoticeIndex = null)
        {
            _client = _client ?? Client.CreateFromConfig();
        }

	    #endregion

        #region Searching

        public ITypeSearch<EpiFindNotice> Query { get; set; }
        public NoticesSearchOptions SearchOptions { get; private set; }
        
        public FilterBuilder<EpiFindNotice> GetFilter { get; private set; }

        public ITypeSearch<EpiFindNotice> CreateQuery(NoticesSearchOptions options)
        {
            SearchOptions = options;
            GetFilter = new FilterBuilder<EpiFindNotice>(_client);
            Query = _client.Search<EpiFindNotice>();
            return Query;
        }

        public SearchResults<EpiFindNotice> ExecuteQuery(FilterBuilder<EpiFindNotice> filter = null)
        {
            //apply filter
            filter = filter ?? GetFilter;
            Query = Query.Filter(filter);

            int? from = null, takeCount = null;
            if (!SearchOptions.SearchAll)
            {
                from = (SearchOptions.mpage - 1) * SearchOptions.PageSize;
                takeCount = SearchOptions.PageSize;
            }

            Query = ApplyOrdering(Query, SearchOptions.SortAsEnum);

            //pagination
            if (from.HasValue)
                Query = Query.Skip(from.Value);

            var result = Query.Take(takeCount ?? 1000).GetResult();
            return result;
        }

        public ITypeSearch<EpiFindNotice> ApplyOrdering(ITypeSearch<EpiFindNotice> source, NoticesSearchOptions.SortOptions sortOptions)
        {
            switch (sortOptions)
            {
                case NoticesSearchOptions.SortOptions.Surname:
                    return source.OrderBy(x => x.Surname);
                case NoticesSearchOptions.SortOptions.DateOfDeath:
                    return source.OrderByDescending(x => x.DateOfDeath);
            }
            return source;
        } 
        #endregion

        public void Add(FuneralNotice funeralNotice)
        {
            if(funeralNotice.Id < 1)
                throw new ValidationException("Can`t Index notice, with ID=0");

            var notice = new EpiFindNotice(funeralNotice);

            
            _client.Index(notice);
            _logger.Log(funeralNotice, AuditState.Indexed);
            
        }

        public void Delete(FuneralNotice funeralNotice)
        {
            var notice = new EpiFindNotice(funeralNotice);

            try
            {
                _client.Delete<EpiFindNotice>(notice.Id);
            }
            catch (Exception ex)
            {
                _logger.Log(funeralNotice, new EpiFindException("Delete failed", ex));
            }
        }

        public EpiFindNotice GetNotice(FuneralNotice funeralNotice)
        {
            var notice = new EpiFindNotice(funeralNotice);
            var result = _client.Get<EpiFindNotice>(notice.Id);
            return result;
        }

        /// <summary>
        /// WARNING - clears whole index
        /// </summary>
        public void ClearAllNoticesInIndex()
        {
            _client.Delete<FuneralNotice>(x => x.Id.InRange(0, Int64.MaxValue)); 
        }


        #region Reindex job
        public int ReindexedCount { get; set; }
        public bool ReIndexShouldStop { get; set; }

        public string ReIndexAll()
        {
            ReindexedCount = 0;
            var builder = new StringBuilder();
            var watch = new Stopwatch();
            watch.Start();

            DateTime prevWeek = DateTime.UtcNow.AddDays(-7);
            using (var ctx = new NoticesContext())
            {
                IEnumerable<FuneralNotice> results = ctx.FuneralNotices.Where(x =>
                                            (x.DateOfFuneral > prevWeek) //funeral
                                            || !String.IsNullOrEmpty(x.OnlineMemorialUrl) //online
                    ).Select(x => x).ToList();

                foreach (FuneralNotice fn in results)
                {
                    Add(fn);
                    ReindexedCount++;

                    if (ReIndexShouldStop)
                        break;
                }
            }
            watch.Stop();

            string completed = (!ReIndexShouldStop) ? "ReIndexAll compleated. <br/>" : "ReIndexAll was stopped. <br/>";
            builder.AppendLine(completed);
            builder.AppendLine("Execution time: {0}minutes {1}seconds <br/>".Frmt(watch.Elapsed.Minutes, watch.Elapsed.Seconds));
            builder.AppendLine("Number of items indexed: {0} <br/>".Frmt(ReindexedCount));
            return builder.ToString();
        } 
        #endregion

    }

    
}
