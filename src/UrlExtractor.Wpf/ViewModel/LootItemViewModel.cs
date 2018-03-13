using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;
using UrlExtractor.Wpf.Model;

namespace UrlExtractor.Wpf.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LootItemViewModel
    {
        private LootItem Item { get; }

        public LootItemViewModel(string rawItemText)
        {
            Item = new LootItem(rawItemText);
        }

        public LootItemViewModel(LootItem item)
        {
            Item = item;
        }

        public async Task PopulatePriceInfoFromWeb()
        {
            ItemPriceFromWeb = "- retrieving item price information... -";
            
            // var result = await ItemPriceLookupModel.GetItemPriceFromWeb(Item);

            ItemPriceFromWeb = await Task.FromResult("NO WEB FOR YOU"); // result;
        }
        
        public string RawItemText => Item.RawItemText;

        public string[] RawSections => Item.RawSections;

        public string ItemPriceFromWeb { get; private set; } = "- no price information retrieved -";

        
    }
}
