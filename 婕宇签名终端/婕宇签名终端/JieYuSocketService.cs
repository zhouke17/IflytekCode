using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using WebSocketSharp;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;

namespace iflytek.Court.Client.Views.Sign_JieYuHelper
{
    /// <summary>
    /// 捷宇科技签字版WebSocket客户端服务
    /// </summary>
    public class JieYuSocketService
    {
        public event EventHandler OnOpen;
        public event EventHandler<CloseEventArgs> OnClose;
        public event EventHandler<ErrorEventArgs> OnError;
        public event Action<object, JObject> OnReceiveMessage;
        private static WebSocket _webSocket { get; set; } = null;
        private static string _serverAddress { get; set; } = "ws://127.0.0.1:1919";
        private static readonly object _locker = new object();
        private static JieYuSocketService _instance = null;
        private static string ZNXXJHZDServicePath { get; set; }

        public static JieYuSocketService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new JieYuSocketService();
                        }
                    }
                }
                return _instance;
            }
        }

        private JieYuSocketService()
        {
            WebSocket.FragmentLength = 1024 * 1024 * 2;
            _webSocket = new WebSocket(_serverAddress);
            _webSocket.WaitTime = new TimeSpan(0, 0, 5);
            Binding();
        }
        ~JieYuSocketService()
        {
            _webSocket?.Close();
        }
        public void Connection()
        {
            _webSocket?.Connect();
        }
        public void Closed()
        {
            _webSocket?.Close();
        }
        public bool Vertify()
        {
            switch (_webSocket?.ReadyState ?? WebSocketState.Closed)
            {
                case WebSocketState.Open:
                    return true;
                case WebSocketState.Closed:
                case WebSocketState.Connecting:
                    return false;
                default: break;
            }
            return false;
        }

        public void Send(string msg)
        {
            if (Vertify())
            {
                _webSocket?.Send(msg);
            }
            else
            {
                //LogManager.SystemLogger.Debug("SendAsync方法超时");
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
            Process[] ps = Process.GetProcessesByName("ZNXXJHZDService");
            foreach (Process p in ps)
            {
                ZNXXJHZDServicePath = p.MainModule?.FileName?.ToString();
            }
            if (!string.IsNullOrEmpty(ZNXXJHZDServicePath))
            {
                File.WriteAllText("ZNXXJHZDServicePath.txt", ZNXXJHZDServicePath);
            }
        }

        private void _webSocket_OnMessage(object sender, MessageEventArgs e)
        {
            var receiveMsg = (JObject)JsonConvert.DeserializeObject(e.Data);
            OnReceiveMessage?.Invoke(sender, receiveMsg);
            //LogManager.SystemLogger.Debug(e.Data, $"HWUGSocket接收消息：{e.Data}");
        }

        private void _webSocket_OnClose(object sender, CloseEventArgs e)
        {
            OnClose?.Invoke(sender, e);
            //LogManager.SystemLogger.Error(e.Reason, "HWUGSocket关闭原因！");
        }

        private void _webSocket_OnError(object sender, ErrorEventArgs e)
        {
            //LogManager.SystemLogger.Error(e.Message, "HWUGSocket连接出错！");
            OnError?.Invoke(sender, e);
        }

        #endregion

    }
}
