using System;
using Showoff.Core.Features.Extensions;

namespace Showoff.Notices.BusinessLogic.EpiFind
{
    public class NoticesSearchOptions
    {
        private int pageSize;
        private double settingMinSimilarity;

        public NoticesSearchOptions()
        {
            this.SortBy = (int)SortOptions.DateOfDeath;
            mpage = 1;
            PageSize = 10;
            SearchAll = false;
        }

        public double SettingMinSimilarity
        {
            get { return settingMinSimilarity == default(double) ? 0.44 : settingMinSimilarity; }
            set { settingMinSimilarity = value; }
        }

        public int mpage { get; set; }

        public int PageSize
        {
            get { return (pageSize == default(int) || pageSize > 1000) ? 1000 : pageSize; } //limit from EpiFind
            set { pageSize = value; }
        }
        public bool SearchAll { get; set; }

        public int SortBy { get; set; }

        public SortOptions SortAsEnum
        {
            get { return this.SortBy.ParseEnumOrDefault<SortOptions>(); }
        }

        public string Letter { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }

        public int DayOfDod { get; set; }
        public int MonthOfDod { get; set; }
        public int YearOfDod { get; set; }

        public enum SortOptions
        {
            DateOfDeath = 0,
            Surname = 1
        }
    }
}
