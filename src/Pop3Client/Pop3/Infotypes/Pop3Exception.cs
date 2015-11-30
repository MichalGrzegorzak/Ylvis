using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pop3.Infotypes
{
    /// <summary>
    /// If anything goes wrong within Pop3MailClient, a Pop3Exception is raised
    /// </summary>
    public class Pop3Exception : ApplicationException
    {
        /// <summary>
        /// Pop3 exception with no further explanation
        /// </summary>
        public Pop3Exception() { }
        /// <summary>
        /// Pop3 exception with further explanation
        /// </summary>
        public Pop3Exception(string ErrorMessage) : base(ErrorMessage) { }
    }
}
