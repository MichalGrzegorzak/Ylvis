using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showoff.Notices.BusinessLogic.Helpers
{
    /// <summary>
    /// Just a marker for EpiFind exceptions
    /// </summary>
    public class EpiFindException : Exception
    {
        public EpiFindException() : base()
        {
        }
        public EpiFindException(string message) : base(message)
        {
        }
        public EpiFindException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
