using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pop3.Infotypes
{
    /// <summary>
    /// A pop 3 connection goes through the following states:
    /// </summary>
    public enum Pop3ConnectionStateEnum
    {
        /// <summary>
        /// undefined
        /// </summary>
        None = 0,
        /// <summary>
        /// not connected yet to POP3 server
        /// </summary>
        Disconnected,
        /// <summary>
        /// TCP connection has been opened and the POP3 server has sent the greeting. POP3 server expects user name and password
        /// </summary>
        Authorization,
        /// <summary>
        /// client has identified itself successfully with the POP3, server has locked all messages 
        /// </summary>
        Connected,
        /// <summary>
        /// QUIT command was sent, the server has deleted messages marked for deletion and released the resources
        /// </summary>
        Closed
    }
}
