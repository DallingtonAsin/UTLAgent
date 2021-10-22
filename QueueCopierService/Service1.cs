using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using PegBank.Queues;
using PegBank.Queues.QueueObjects;

namespace QueueCopierService
{
    public partial class Service1 : ServiceBase
    {
        QueueObjectHandler dataObj = new QueueObjectHandler();
        public string DepositQueueName;
        public Service1()
        {
            DepositQueueName = dataObj.DepositQueue;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        class CustomerDetails
        {
           public  string account_number;
           public  double amount;
        }



        public MessageQueue fetchDepositQueue()
        {
            DepositQueue obj = null;
            MessageQueue queue = null;
            try
            {
                obj = new DepositQueue();
                queue = obj.getQueue(DepositQueueName);
                return queue;


            }catch(Exception ex)
            {
                throw ex;
                return null;
            }
        }

        


        public void CreateDepositQueueCopy(MessageQueue queue)
        {

        }



        public object[] ReceiveQueueMessage(string QueueName)
        {

            MessageQueue myQueue = null;
            try
            {

                myQueue = new MessageQueue(QueueName);
                myQueue.Formatter = new XmlMessageFormatter(new Type[]
                {typeof(CustomerDetails)});

                Message message = myQueue.Receive();

                CustomerDetails details = (CustomerDetails)message.Body;
                string acc_no = details.account_number;
                double amt = details.amount;
                object[] data = { acc_no, amt };
                return data;

            }

            catch (MessageQueueException ex)
            {
                throw ex;
                return null;
            }


            catch (InvalidOperationException e)
            {
                throw e;
                return null;
            }
            catch (Exception x)
            {
                throw x;
                return null;
            }


        }



    }
}
