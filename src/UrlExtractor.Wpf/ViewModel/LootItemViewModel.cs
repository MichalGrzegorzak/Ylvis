using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;
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
            ItemPriceFromWeb = "- retrieving item price information... -";
            
            // var result = await ItemPriceLookupModel.GetItemPriceFromWeb(Item);

            ItemPriceFromWeb = await Task.FromResult("NO WEB FOR YOU"); // result;
        }
        
        public string RawItemText => Item.Text;

        public string[] RawSections => Item.Downloads.ToArray();

        public string ItemPriceFromWeb { get; private set; } = "- no price information retrieved -";

        
    }
}
