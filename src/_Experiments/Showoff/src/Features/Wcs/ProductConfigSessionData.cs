using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Showoff.Core.Features.SessionState;

namespace Showoff.Web.Core.Features.Wcs
{
    [Serializable]
    public class ProductConfigSessionData : ISessionData
    {
        public ProductConfigSessionData()
        {
            Init();
        }
        private void Init()
        {
            _dict = new Dictionary<string, string>();
            Online = new WcsOnlineFields(_dict);
        }


        public string ReffererUrl { get; set; }
        public string LastSuccessfullOrderId { get; set; }
        public string IncompatibleProduct { get; set; }
        public string AbandonPurchaseError { get; set; }
        public bool ShowPopupMessage { get; set; }

        private Dictionary<string, string> _dict;
        public Dictionary<string, string> Configuration
        {
            get { return _dict; }
            set
            {
                _dict = value;
                Online = new WcsOnlineFields(_dict);
            }
        }

        //public WcsInterfloraFields Interflora { get; set; }
        public WcsOnlineFields Online { get; set; } 
        //TODO -> GENERAL
        
        

        public void Clear()
        {
            Init();
            ShowPopupMessage = false;
            AbandonPurchaseError = null;
            IncompatibleProduct = null;
        }

    }

    [Serializable]
    public class ProductConfigPostData : ProductConfigSessionData
    {
        [Url]
        public string productURL { get; set; }
    }
}