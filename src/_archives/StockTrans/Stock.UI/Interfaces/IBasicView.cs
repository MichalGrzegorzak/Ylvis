using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Core.Domain;

namespace Stock.Interfaces
{
    public interface IBasicView<T> where T : DomainObject<Int32>
    {
        ICollection<T> ItemsList { set; }
        event EventHandler ItemsListChanged;
        
        event EventHandler ItemChanged;
        event EventHandler AddItem;
        event EventHandler GetItem;
        //event EventHandler ItemDelete;
    }
}
