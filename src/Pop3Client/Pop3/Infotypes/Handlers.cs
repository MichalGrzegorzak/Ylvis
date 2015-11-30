using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pop3.Infotypes
{
    // Delegates for Pop3MailClient
    // ============================

    /// <summary>
    /// If POP3 Server doesn't react as expected or this code has a problem, but
    /// can continue with the execution, a Warning is called.
    /// </summary>
    /// <param name="WarningText"></param>
    /// <param name="Response">string received from POP3 server</param>
    public delegate void WarningHandler(string WarningText, string Response);


    /// <summary>
    /// Traces all the information exchanged between POP3 client and POP3 server plus some
    /// status messages from POP3 client.
    /// Helpful to investigate any problem.
    /// Console.WriteLine() can be used
    /// </summary>
    public delegate void TraceHandler(string TraceText);
}
