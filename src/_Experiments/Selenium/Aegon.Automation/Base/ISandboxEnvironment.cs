using System;
using System.Collections.Generic;

namespace Aegon.Base
{
    public interface ISandboxEnvironment
    {
        string Browser { get; set; }
        IDictionary<string, string> BaseUrls { get; set; }
        string UserLogin { get; set; }
        string UserPassword { get; set; }
        string ExtensionsBasePath { get; set; }
        string LocalExtensionsNames { get; set; }
        int PageLoadTimeout { get; set; }

        bool SignIn(WebBrowser sandbox);
        bool UseEmbededChrome { get; set; }
    }
}