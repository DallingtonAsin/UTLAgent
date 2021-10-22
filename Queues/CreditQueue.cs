using System;
using System.Messaging;
using UTLAgent.Queues.QueueObjects;
namespace UTLAgent.Queues
{
    public class CreditQueue
    {



        QueueObjectHandler objectData = new QueueObjectHandler();
        public QueueManager manager = new QueueManager();
      
        //populates deposit queue with new data parameters
        public void Enqueue(object[] paras)
        {
            manager.SendQueueMessage(objectData.CreditQueueName, paras);
        }

        public void Dequeue(string messageId)
        {
            manager.DequeueMessage(objectData.CreditQueueName, messageId);
        }
         //returns depositMoney queue
        public MessageQueue GetQueue()
        {
           MessageQueue queue = manager.getQueue(objectData.CreditQueueName);
            return queue;
        }
       
        //Gets and removes a message from a queue
       public object[] ReceiveQueueMessage()
        {
          object[] data =  manager.ReceiveMessageFromQueue(objectData.CreditQueueName);
          return data;
         
        }

       
        public object[] PeekQueueMessage()
        {
           object[] data = manager.PickMessageFromQueue(objectData.CreditQueueName);
            return data;
        }



        //checks if a credit queue is empty
        public bool isQueueEmpty(MessageQueue queue)
        {
            queue =  manager.getQueue(objectData.CreditQueueName);
            bool response = manager.isQueueEmpty(queue);
            return response;
        }

    }
}