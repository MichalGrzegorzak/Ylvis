using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionsLib.Components
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
