﻿using Apache.NMS;
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

namespace MQProducer
{
    public partial class Producer : Form
    {
        public Producer()
        {
            InitializeComponent();
            InitProducer();
        }

        private IConnectionFactory factory;

        public void InitProducer()
        {
            try
            {
                //初始化工厂，这里默认的URL是不需要修改的
                factory = new ConnectionFactory("tcp://localhost:61616");
            }
            catch
            {
                label1.Text = "初始化失败!!";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //通过工厂建立连接
            using (IConnection connection = factory.CreateConnection())
            {
                //通过连接创建Session会话
                using (ISession session = connection.CreateSession())
                {
                    //通过会话创建生产者，方法里面new出来的是MQ中的Queue
                    IMessageProducer prod = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("ActiveMQTest"));

                    #region 发送结构信息

                    //Student studentModel = new Student();
                    //studentModel.Grade = "三年级"; 
                    //studentModel.Name = "张三";
                    //studentModel.Sex = "男";
                    //studentModel.Age = "23";

                    //string temp = JsonConvert.SerializeObject(studentModel); 
                    //ITextMessage message = prod.CreateTextMessage(temp);  

                    #endregion

                    #region 发送文本信息

                    //创建一个发送的消息对象
                    ITextMessage message = prod.CreateTextMessage();
                    //给这个对象赋实际的消息
                    message.Text = textBox1.Text;

                    #endregion 

                    //设置消息对象的属性，这个很重要哦，是Queue的过滤条件，也是P2P消息的唯一指定属性
                    message.Properties.SetString("filter", "SwipeCard");
                    //生产者把消息发送出去，几个枚举参数MsgDeliveryMode是否长链，MsgPriority消息优先级别，发送最小单位，当然还有其他重载
                    prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                    label1.Text = "发送成功!!";
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
