namespace Ylvis.Utils.Features.Paging
{
    public interface IPager
    {
        int PageId { get; }
        int PageSize { get; set; }
        int Count { get; set; }
        bool SortDescending { get; set; }

        void BindData(int count);

        /// <summary>
        /// Can be ONLY used with extension OrderBy('string colName')
        /// </summary>
        string OrderBy { get; set; }
    }
}
