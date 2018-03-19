using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AServiceContract
{
    [DataContract]
    public class Account
    {
        public Account()
        {
        }

        public Account(Credentials cr)
        {
            this.cred = cr;
            this.Id = cr.AccountId;
        }

        [DataMember]
        public int Id;
        [DataMember]
        public string Name;
        [DataMember]
        public int Limit = 2;
        [DataMember]
        public Position Pos;
        [DataMember]
        public bool Enabled;

        public Credentials cred;
    }
}
