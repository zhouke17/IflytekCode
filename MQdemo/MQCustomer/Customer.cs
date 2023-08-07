using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQCustomer
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            InitConsumer();
        }

        public void InitConsumer()
        {
            //创建连接工厂
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            //通过工厂构建连接
            IConnection connection = factory.CreateConnection();
            //这个是连接的客户端名称标识
            connection.ClientId = "SwipeCardActionListener";
            //启动连接，监听的话要主动启动连接
            connection.Start();
            //通过连接创建一个会话
            ISession session = connection.CreateSession();
            //通过会话创建一个消费者，这里就是Queue这种会话类型的监听参数设置
            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("ActiveMQTest"), "filter='SwipeCard'");
            //注册监听事件
            consumer.Listener += new MessageListener(consumer_Listener);
            //  connection.Stop();
            //  connection.Close();
        }

        void consumer_Listener(IMessage message)
        {
            #region 接收结构类型

            //try
            //{
            //    ActiveMQTextMessage receiveMsg = message as ActiveMQTextMessage;

            //    Student studentModel = JsonConvert.DeserializeObject<Student>(receiveMsg.Text);

            //    tbReceiveMessage.Invoke(new DelegateRevMessage(RevMessage), receiveMsg);
            //}
            //catch (Exception ex)
            //{

            //}

            #endregion

            #region 接收文本类型

            ITextMessage msg = (ITextMessage)message;
            textBox1.Invoke(new DelegateRevMessage(RevMessage), msg);

            #endregion
        }

        public delegate void DelegateRevMessage(ITextMessage message);

        public void RevMessage(ITextMessage message)
        {
            textBox1.Text += string.Format(@"接收到:{0}{1}", message.Text, Environment.NewLine);
        }
    }
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Grade { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Sex { get; set; }

        [DataMember]
        public string Age { get; set; }
    }
}
