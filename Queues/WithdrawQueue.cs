using System;
using System.Messaging;
using UTLAgent.Queues.QueueObjects;
namespace UTLAgent.Queues
{
    public class WithdrawQueue
    {



        QueueObjectHandler objectData = new QueueObjectHandler();
        public QueueManager manager = new QueueManager();

        //populates deposit queue with new data parameters
        public void Enqueue(object[] paras)
        {
            manager.SendQueueMessage(objectData.WithdrawQueueName, paras);
        }

        public void Dequeue(string message_id)
        {
            manager.DequeueMessage(objectData.WithdrawQueueName, message_id);
        }
        //returns depositMoney queue
        public MessageQueue GetQueue()
        {
            MessageQueue queue = manager.getQueue(objectData.WithdrawQueueName);
            return queue;
        }

        //Gets and removes a message from a queue
        public object[] ReceiveQueueMessage()
        {
            object[] data = manager.ReceiveMessageFromQueue(objectData.WithdrawQueueName);
            return data;

        }


        public object[] PeekQueueMessage()
        {
            object[] data = manager.PickMessageFromQueue(objectData.WithdrawQueueName);
            return data;
        }



        //checks if a deposit queue is empty
        public bool isQueueEmpty(MessageQueue queue)
        {
            queue = manager.getQueue(objectData.WithdrawQueueName);
            bool response = manager.isQueueEmpty(queue);
            return response;
        }

    }
}