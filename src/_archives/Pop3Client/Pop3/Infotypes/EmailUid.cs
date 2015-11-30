using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pop3.Infotypes
{
    /// <summary>
    /// Combines Email ID with Email UID for one email
    /// The POP3 server assigns to each message a unique Email UID, which will not change for the life time
    /// of the message and no other message should use the same.
    /// 
    /// Exceptions:
    /// Throws Pop3Exception if there is a serious communication problem with the POP3 server, otherwise
    /// 
    /// </summary>
    public struct EmailUid
    {
        /// <summary>
        /// used in POP3 commands to indicate which message (only valid in the present session)
        /// </summary>
        public int EmailId;
        /// <summary>
        /// Uid is always the same for a message, regardless of session
        /// </summary>
        public string Uid;

        /// <summary>
        /// constructor
        /// </summary>
        public EmailUid(int EmailId, string Uid)
        {
            this.EmailId = EmailId;
            this.Uid = Uid;
        }
    }
}
