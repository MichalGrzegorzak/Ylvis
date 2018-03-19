using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using EPiServer.Find;
using EPiServer.Find.Api.Querying;
using Showoff.Notices.DAL.Entities;

namespace Showoff.Notices.BusinessLogic.EpiFind
{
    public interface INoticesIndexer
    {
        IClient NoticeClient { get; }
        ITypeSearch<EpiFindNotice> Query { get; set; }
        NoticesSearchOptions SearchOptions { get; }
        FilterBuilder<EpiFindNotice> GetFilter { get; }
        int ReindexedCount { get; set; }
        bool ReIndexShouldStop { get; set; }
        void CreateClients(IClient clientNoticeIndex = null);
        ITypeSearch<EpiFindNotice> CreateQuery(NoticesSearchOptions options);
        SearchResults<EpiFindNotice> ExecuteQuery(FilterBuilder<EpiFindNotice> filter = null);
        ITypeSearch<EpiFindNotice> ApplyOrdering(ITypeSearch<EpiFindNotice> source, NoticesSearchOptions.SortOptions sortOptions);
        void Add(FuneralNotice funeralNotice);
        void Delete(FuneralNotice funeralNotice);
        EpiFindNotice GetNotice(FuneralNotice funeralNotice);

        void ClearAllNoticesInIndex();
        string ReIndexAll();
    }
}
