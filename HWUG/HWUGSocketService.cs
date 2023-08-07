using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace HWUG
{
    public class HWUGSocketService
    {

        public event EventHandler OnOpen;
        public event EventHandler<CloseEventArgs> OnClose;
        public event EventHandler<ErrorEventArgs> OnError;
        public event Action<object, JObject> OnReceiveMessage;
        public event Action<object, bool> OnVerifyingEventHandler;
        private static WebSocket _webSocket { get; set; } = null;
        //private static string _serverAddress { get; set; } = "ws://127.0.0.1:12100/pc";
        private static string _serverAddress { get; set; } = "ws://127.0.0.1:1919";
        private static readonly object _locker = new object();
        private static HWUGSocketService _instance = null;

        public static HWUGSocketService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new HWUGSocketService();
                        }
                    }
                }
                return _instance;
            }
        }



        private HWUGSocketService()
        {
            WebSocket.FragmentLength = 1024 * 1024 * 2;
            _webSocket = new WebSocket(_serverAddress);
            _webSocket.WaitTime = new TimeSpan(0, 0, 5);
            Binding();
        }
        ~HWUGSocketService()
        {
            _webSocket?.Close();
        }
        public void Connection()
        {
            _webSocket.Connect();
        }
        public void Closed()
        {
            _webSocket?.Close();
        }
        public bool Vertify()
        {
            DateTime start = DateTime.Now.AddSeconds(5);
            while (DateTime.Now.CompareTo(start) <= 0)
            {
                switch (_webSocket?.ReadyState ?? WebSocketState.Closed)
                {
                    case WebSocketState.Open:
                        return true;
                    case WebSocketState.Closed:
                    case WebSocketState.Connecting:
                        _webSocket.Connect();
                        break;
                    default: break;
                }
            }
            return false;
        }

        public void SendAsync(string msg)
        {
            if (Vertify())
            {
                _webSocket.SendAsync(msg, (res)=> { });
            }
            else
            {
                //LogService.WriteLogToFile(LogLibrary.LogLevel.ERROR, "SOCKET 连接超时！", "SOCKET错误");
            }
        }
        #region listen binding

        private void Binding()
        {
            _webSocket.OnOpen += _webSocket_OnOpen;
            _webSocket.OnMessage += _webSocket_OnMessage;
            _webSocket.OnClose += _webSocket_OnClose;
            _webSocket.OnError += _webSocket_OnError;
        }

        private void _webSocket_OnOpen(object sender, EventArgs e)
        {
            OnOpen?.Invoke(sender, e);
        }

        private void _webSocket_OnMessage(object sender, MessageEventArgs e)
        {
            var receiveMsg = (JObject)JsonConvert.DeserializeObject(e.Data);
            OnReceiveMessage?.Invoke(sender, receiveMsg);
            //LogService.WriteLogToFile(LogLibrary.LogLevel.MESSAGE, $"接收到的消息：{e.Data}", "SOCKET消息");
        }

        private void _webSocket_OnClose(object sender, CloseEventArgs e)
        {
            OnClose?.Invoke(sender, e);
            Task.Factory.StartNew(() =>
            {
                while ((_webSocket?.ReadyState ?? WebSocketState.Closed) == WebSocketState.Closed)
                {
                    _webSocket.ConnectAsync();
                    Thread.Sleep(3000);
                }
            });
        }

        private void _webSocket_OnError(object sender, ErrorEventArgs e)
        {
            //LogService.WriteLogToFile(LogLibrary.LogLevel.ERROR, "SOCKET 错误！详细信息：" + e.Message, "SOCKET错误");
            OnError?.Invoke(sender, e);
        }

        #endregion

    }
}
