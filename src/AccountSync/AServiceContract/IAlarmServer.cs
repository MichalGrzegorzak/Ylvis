using System;
using System.Collections.Generic;
using System.Threading;
using System.ServiceModel;
using System.Collections;
using System.Runtime.Serialization;

namespace AServiceContract
{
    [ServiceContract(Name="AlarmServer",
        CallbackContract=typeof(IAlarmCallback), 
        SessionMode=SessionMode.Required)]
    public interface IAlarmServer
    {
        [OperationContract(IsOneWay = true)]
        void DetectPosition();

        [OperationContract(IsOneWay = true)]
        void ChangePosition(int size, string direct, int price, DateTime date);
        
        [OperationContract(IsOneWay = true)]
        void ConnectOperator();

        [OperationContract(IsOneWay = true)]
        void DisconnectOperator();

        [OperationContract()]
        bool CancelLastSignal(bool decision);

        [OperationContract()]
        List<Account> GetAccounts();
    }

    
    

    
}
