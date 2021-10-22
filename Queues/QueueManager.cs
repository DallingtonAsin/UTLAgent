using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Messaging;
using System.Net.Configuration;

namespace UTLAgent.Queues
{
    public class QueueManager 
    {

        public class AgentDetails
        {
            public string requestId;
            public string account_number;
            public double amount;
            public string creditedBy;
            public string messageId;


        }


        public MessageQueue getQueue(string queueName)
        {

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
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       
        public void SendQueueMessage(string QueueName, object[] paras)
        {


              AgentDetails details = new AgentDetails();
              details.requestId = Convert.ToString(paras[0]);
              details.account_number = Convert.ToString(paras[1]);
              details.amount = Convert.ToDouble(paras[2]);
              details.creditedBy = Convert.ToString(paras[3]);

            MessageQueue queue = null;
            Message message = null;
           
            try
            {
                queue = getQueue(QueueName);
                message = new Message();
                details.messageId = message.Id;
                message.Body = details;
                message.Recoverable = true;
                queue.Send(message);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool isQueueEmpty(MessageQueue queue)
        {
            var queueNum = queue.GetMessageEnumerator2();
            bool response = false;
            if (queueNum.MoveNext())
            {
                response = false; //not empty
            }
            else
            {
                response = true; //empty
            }
            return response;
        }

        public object[] ReceiveMessageFromQueue(string QueueName)
        {

            MessageQueue myQueue = null;
            try
            {

                myQueue = new MessageQueue(QueueName);
                myQueue.Formatter = new XmlMessageFormatter(new Type[]
                {typeof(AgentDetails)});

                Message message = myQueue.Receive();
                AgentDetails details = (AgentDetails)message.Body;

                string requestId = details.requestId;
                string acc_no = details.account_number;
                double amt = details.amount;
                string creditedBy = details.creditedBy;
                string message_id = message.Id;
                object[] data = { requestId, acc_no, amt, creditedBy, message_id};
                return data;

            }

            catch (MessageQueueException ex)
            {
                throw ex;
            }


            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception x)
            {
                throw x;
            }


        }


        public object[] PickMessageFromQueue(string QueueName)
        {

            MessageQueue myQueue = null;
            try
            {

                myQueue = new MessageQueue(QueueName);
                myQueue.Formatter = new XmlMessageFormatter(new Type[]
                {typeof(AgentDetails)});

                Message message = myQueue.Peek();

                AgentDetails details = (AgentDetails)message.Body;

                string requestId = details.requestId;
                string acc_no = details.account_number;
                double amt = details.amount;
                string creditedBy = details.creditedBy;
                string message_id = message.Id;
                object[] data = {requestId, acc_no, amt, creditedBy, message_id};

                return data;

            }

            catch (MessageQueueException ex)
            {
                throw ex;
            }


            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception x)
            {
                throw x;
            }


        }


        public void DequeueMessage(string QueueName, string Id)
        {

            MessageQueue myQueue = null;
            try
            {

                myQueue = new MessageQueue(QueueName);
                myQueue.Formatter = new XmlMessageFormatter(new Type[]
                {typeof(AgentDetails)});
                myQueue.ReceiveById(Id);
                

            }

            catch (MessageQueueException ex)
            {
                throw ex;
            }


            catch (InvalidOperationException e)
            {
                throw e;
              
            }
            catch (Exception x)
            {
                throw x;
            }


        }








        //**********JUST MY RECYCLE BIN***************
        /*
                public class Field
                {
                    public string FieldName;
                    public Type FieldType;
                    public Field(string name, Type type)
                    {
                        this.FieldName = name;
                        this.FieldType = type;
                    }


                }


                public class DynamicClass : DynamicObject
                {
                    private Dictionary<string, KeyValuePair<Type, object>> _fields;

                    public DynamicClass(List<Field> fields)
                    {
                        _fields = new Dictionary<string, KeyValuePair<Type, object>>();
                        fields.ForEach(x => _fields.Add(x.FieldName,
                            new KeyValuePair<Type, object>(x.FieldType, null)));
                    }

                    public override bool TrySetMember(SetMemberBinder binder, object value)
                    {
                        if (_fields.ContainsKey(binder.Name))
                        {
                            var type = _fields[binder.Name].Key;
                            if (value.GetType() == type)
                            {
                                _fields[binder.Name] = new KeyValuePair<Type, object>(type, value);
                                return true;
                            }
                            else throw new Exception("Value " + value + " is not of type " + type.Name);
                        }
                        return false;
                    }

                    public override bool TryGetMember(GetMemberBinder binder, out object result)
                    {
                        result = _fields[binder.Name].Value;
                        return true;
                    }
                }


                public static MyClass createInstance<MyClass>() where MyClass : new()
                {
                    return new MyClass();
                }

                public static object CreateInstance(Type type)
                {
                    return Activator.CreateInstance(type);
                }


                */











    }
}