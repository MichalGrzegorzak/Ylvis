using System;
using System.Collections.Generic;
using Showoff.Core.Features.Extensions;
using Showoff.Web.Models.ViewModels.Wcs;

namespace Showoff.Web.Core.Features.Wcs
{
    [Serializable]
    public class WcsBaseFields : IWcsFielsd
    {
        protected Dictionary<string, string> dict;

        public WcsBaseFields()
        {
        }
        public WcsBaseFields(Dictionary<string, string> sessionDict)
        {
            dict = sessionDict;
        }

        public string clearBasket { get { return dict.GetOrDefault("clearBasket"); } set { dict["clearBasket"] = value; } }
        public string orderId { get { return dict.GetOrDefault("orderId"); } set { dict["orderId"] = value; } }
        public string orderItemId { get { return dict.GetOrDefault("orderItemId"); } set { dict["orderItemId"] = value; } }

        public string memberid { get { return dict.GetOrDefault("memberid"); } set { dict["memberid"] = value; } }
        public string storeId { get { return dict.GetOrDefault("storeId"); } set { dict["storeId"] = value; } }
        public string langId { get { return dict.GetOrDefault("langId "); } set { dict["langId "] = value; } }
        public string catalogId { get { return dict.GetOrDefault("catalogId"); } set { dict["catalogId"] = value; } }
        public string URL { get { return dict.GetOrDefault("URL"); } set { dict["URL"] = value; } }
        public string errorViewName { get { return dict.GetOrDefault("errorViewName"); } set { dict["errorViewName"] = value; } }
        public string fromFlow { get { return dict.GetOrDefault("fromFlow"); } set { dict["fromFlow"] = value; } }
        

        public string productURL { get { return dict.GetOrDefault("productURL"); } set { dict["productURL"] = value; } }
        public string partNumber_0 { get { return dict.GetOrDefault("partNumber_0"); } set { dict["partNumber_0"] = value; } }
        public string price_0 { get { return dict.GetOrDefault("price_0"); } set { dict["price_0"] = value; } }
        public string quantity_0 { get { return dict.GetOrDefault("quantity_0"); } set { dict["quantity_0"] = value; } }

        public string orderconfigfNumber { get { return dict.GetOrDefault("orderconfigfNumber"); } set { dict["orderconfigfNumber"] = value; } }
        public string orderconfigparentbranchId { get { return dict.GetOrDefault("orderconfigparentbranchId"); } set { dict["orderconfigparentbranchId"] = value; } }

        public string Error { get { return dict.GetOrDefault("Error"); } set { dict["Error"] = value; } }
    }
}