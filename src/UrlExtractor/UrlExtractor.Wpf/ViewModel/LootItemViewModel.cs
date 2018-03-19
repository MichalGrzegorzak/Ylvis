using System;
using PropertyChanged;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using UrlExtractor.Model;
using UrlExtractor.Wpf.Model;

namespace UrlExtractor.Wpf.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LootItemViewModel
    {
        private ClipboardPost Item { get; }

        public LootItemViewModel(string rawItemText)
        {
            Item = PostFactory.CreatePost(rawItemText);
        }

        public LootItemViewModel(ClipboardPost item)
        {
            Item = item;
        }

        public async Task PopulatePriceInfoFromWeb()
        {
            ItemPriceFromWeb = "- saving to file... -";

            // var result = await ItemPriceLookupModel.GetItemPriceFromWeb(Item);

            int count = 0;
            using (var repo = new LiteRepository("test.db"))
            {
                //var allPosts = .ToList();
                repo.Insert(Item);
                count = repo.Query<ClipboardPost>().Count();

            }

            ItemPriceFromWeb = await Task.FromResult($"SAVED count:{count}"); // result;
        }
        
        public string RawItemText => Item.Text;

        public string[] RawSections => Item.Downloads.ToArray();

        public string ItemPriceFromWeb { get; private set; } = "- no price information retrieved -";

        
    }
}
