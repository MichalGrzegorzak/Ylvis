using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons.UI
{
    public interface IMessage
    {
        string Message { get; set; }
    }

    public interface IQuestion
    {
        string Question { get; set; }
        string QuestionDetails { get; set; }
    }
}
