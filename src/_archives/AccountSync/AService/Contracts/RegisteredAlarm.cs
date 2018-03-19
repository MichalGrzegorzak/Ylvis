using System;
using System.Collections.Generic;
using System.Text;
using AServiceContract;

namespace AService
{
    public class RegisteredAlarm
    {
        private string _client;
        private string _message;
        private DateTime _alarmTime;
        private IAlarmCallback _callback;
        private bool _fired = false;

        public bool Fired
        {
            get { return _fired; }
            set { _fired = value; }
        }

        public string ClientName
        {
            get { return _client; }
            set { _client = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public DateTime AlarmTime
        {
            get { return _alarmTime; }
            set { _alarmTime = value; }
        }

        public IAlarmCallback Callback
        {
            get { return _callback; }
            set { _callback = value; }
        }
    }
}
