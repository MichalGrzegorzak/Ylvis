using System.Collections.Generic;
using Aegon.Helpers;

namespace Aegon.Base.TestRunner
{
    internal class PageTypeDictionary
    {
        private readonly int _maxPages;
        private readonly string _rootPath;
        private readonly Dictionary<int, int> _typeUsageDictionary = new Dictionary<int, int>();

        public PageTypeDictionary(string rootPath, int maxPages)
        {
            _maxPages = maxPages;
            _rootPath = rootPath;
        }

        public bool ShouldProcess(string pageUrl)
        {
            if (_maxPages <= 0)
            {
                return true; // sky is the limit
            }

            int typeId = CmsHelper.GetPageTypeId(_rootPath, pageUrl);
            if (typeId < 0)
            {
                return true; // unknown type, so hell, let's try anyway
            }

            if (!_typeUsageDictionary.ContainsKey(typeId))
            {
                _typeUsageDictionary.Add(typeId, 0); // initialize entry so there's always something to work on
            }

            int actualCount = _typeUsageDictionary[typeId];
            _typeUsageDictionary[typeId] = ++actualCount; // increase the counter, let's log how many attempts there have been
            return actualCount <= _maxPages;
        }
    }
}
