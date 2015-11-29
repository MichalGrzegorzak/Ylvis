using System;
using System.Collections.Generic;
using Showoff.Core.Features.Extensions;

namespace Showoff.Web.Core.Features.Wcs
{
    [Serializable]
    public class WcsOnlineFields : WcsBaseFields
    {
        public WcsOnlineFields() : base()
        {
        }
        public WcsOnlineFields(Dictionary<string, string> sessionDict) : base(sessionDict)
        {
        }

        public string configpersonTitle { get { return dict.GetOrDefault("configpersonTitle"); } set { dict["configpersonTitle"] = value; } }
        public string configforeName { get { return dict.GetOrDefault("configforeName"); } set { dict["configforeName"] = value; } }
        public string configsurName { get { return dict.GetOrDefault("configsurName"); } set { dict["configsurName"] = value; } }
        public string confignickName { get { return dict.GetOrDefault("confignickName"); } set { dict["confignickName"] = value; } }
        public string configbirthDate { get { return dict.GetOrDefault("configbirthDate"); } set { dict["configbirthDate"] = value; } }
        public string configdeathDate { get { return dict.GetOrDefault("configdeathDate"); } set { dict["configdeathDate"] = value; } }
    }
}