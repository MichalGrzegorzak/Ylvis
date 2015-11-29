using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AServiceContract
{
    public class OperationState<T> where T : class
    {
        private T _operation;
        private bool? status = null;
        //true = executed, false = cancelled

        public OperationState(T item)
        {
            _operation = item;
            status = null;
        }

        //public enum State
        //{
        //    Executed,
        //    Cancelled,
        //    None
        //}
    }
}
