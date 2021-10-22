using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTLAgent.Queues.QueueObjects
{
    public class QueueObjectHandler
    {

        public string DepositQueueName, CreditQueueName;
        public string WithdrawQueueName;

        public QueueObjectHandler()
        {
            DepositQueueName = ".\\Private$\\depositMoney";
            CreditQueueName = ".\\Private$\\creditMoney";
            WithdrawQueueName = ".\\Private$\\withdrawMoney";

        }
     
    }
}