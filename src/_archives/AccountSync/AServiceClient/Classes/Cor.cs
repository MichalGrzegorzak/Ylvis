using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AServiceAgent;

namespace AServiceClient
{
    public delegate void UpdateUIAccountHandler(int accountId, Position pos);

    public abstract class Cor
    {
        public static event UpdateUIAccountHandler UpdateUIAccount;

        public static AlarmServerClient Client = null;
        public static void CallUpdateUIAccount(int id, Position position)
        {
            UpdateUIAccount.Invoke(id, position);
        }
    }
}
