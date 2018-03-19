using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Accounts;

namespace Core.Model
{
    

    public class OperationsQueue
    {
        private static List<NewPositionArg> operations = new List<NewPositionArg>();
        private static object _locker = new object();

        public void Add(NewPositionArg operation)
        {
            lock (_locker)
            {
                operations.Add(operation);
            }
        }

        public NewPositionArg Get()
        {
            lock (_locker)
            {
                for (int i = 0; i < operations.Count; i++)
                {
                    NewPositionArg arg = operations[i];
                    if (arg.Timeout <= 0)
                    {
                        operations.RemoveAt(i);
                        return arg;
                    }
                    arg.Timeout--;
                }
            }
            return null;
        }

        public bool Update(NewPositionArg action)
        {
            bool result = false;
            lock (_locker)
            {
                int idx = operations.FindIndex((arg) => arg.Account == action.Account);
                if (idx > -1)
                {
                    NewPositionArg act = operations[idx];
                    operations[idx] = action;
                    result = true;
                }

                //    //.Find((arg) =>
                //{
                //    return (arg.Account == action.Account);
                //});
            }
            return result;
        }
    }
}
