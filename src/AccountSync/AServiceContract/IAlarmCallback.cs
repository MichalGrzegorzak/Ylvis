using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace AServiceContract
{
    public interface IAlarmCallback
    {
        [OperationContract(IsOneWay = true)]
        void AlertNewSignal(Position pos);

        [OperationContract(IsOneWay = true)]
        void UpdateUIAccount(Account account);

        [OperationContract(IsOneWay = true)]
        void ServerLogMessages(LogMessage log);
    }

    public class LogMessage
    {
        public string Source;
        public string Message;
        public MessageType Typ;

        public string FullMessage()
        {
            string res = Source + " " + Typ + " " + Message;
            return res;
        }

        public enum MessageType
        {
            Warn,
            Error,
            Fatal,
            Info,
            Debug
        }

    }

}
