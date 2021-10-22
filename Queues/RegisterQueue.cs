using UTLAgent.Pages;
using System;
using System.Messaging;

namespace UTLAgent.Queues
{
    public class RegisterQueue
    {

        private string queueName = ".\\Private$\\registerCustomer";


        public class Customer
        {

            public string fname, lname, telno, email;

        };
        public MessageQueue registerCustomerQueue()
        {
            Message message = null;
            MessageQueue queue = null;
            try
            {
               
                if (MessageQueue.Exists(queueName))
                {
                    queue = new MessageQueue(queueName);
                }
                else
                {
                    queue = MessageQueue.Create(queueName);
                
                }
                return queue;
                

            }catch(Exception ex)
            {
                throw ex;
                return null;
            }
        }


        public void SendMessage(object[] paras)
        {
            Customer customer = new Customer();
            customer.fname = Convert.ToString(paras[0]);
            customer.lname = Convert.ToString(paras[1]);
            customer.telno = Convert.ToString(paras[2]);
            customer.email = Convert.ToString(paras[3]);
            MessageQueue queue = null;
            Message message = null;
            RegisterQueue obj = new RegisterQueue();
            try
            {
                queue = obj.registerCustomerQueue();
                message = new Message();
                message.Body = customer;
                message.Recoverable = true;
                queue.Send(message);

            }
            catch(Exception ex)
            {
                throw ex;
            }
          

        }




    }
}