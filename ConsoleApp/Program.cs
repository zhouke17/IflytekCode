using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    class Program
    {
        #region 变量
        private static int timer1Count = 0;
        private static int timer2Count = 0;
        private static System.Timers.Timer timer1;
        private static System.Threading.Timer timer2;
        #endregion

        static void Main(string[] args)
        {
            #region JObject遍历
            string res = "{  \"error_code\": 0,  \"error_msg\": \"SUCCESS\",  \"log_id\": 3014595066,  \"timestamp\": 1527234617,  \"cached\": 0,  \"result\": {    \"face_token\": \"49d58eacd7811e463429a1ae10b42173\",    \"user_list\": [      {        \"group_id\": \"NR\",        \"user_id\": \"1028867728\",        \"user_info\": \"cactus0117\",        \"score\": 97.499450683594      },      {        \"group_id\": \"BR\",        \"user_id\": \"3456378901\",        \"user_info\": \"cactus0117\",        \"score\":89.499450683594      }    ]  }}";

            string res2 = "{\"success\":\"0\",\"msg\":\"\",\"data\":[{\"id\":null,\"ah\":null,\"ahdm\":null,\"litigantId\":null,\"litigantXh\":null,\"name\":\"李四\",\"ssdw\":\"被告\",\"telephone\":\"\",\"licenceId\":\"\",\"address\":null,\"litigantType\":\"法人\",\"litigantTypeCode\":null},{\"id\":null,\"ah\":null,\"ahdm\":null,\"litigantId\":null,\"litigantXh\":null,\"name\":\"张三\",\"ssdw\":\"原告\",\"telephone\":\"13111111111\",\"licenceId\":\"1234\",\"address\":null,\"litigantType\":\"自然人\",\"litigantTypeCode\":null}]}";

            JObject obj = JObject.Parse(res);
            var obj2 = JsonConvert.DeserializeObject<JObject>(res);
            var obj3 = (dynamic)JObject.Parse(res2);

            List<string> list = new List<string>();
            foreach (var item in obj3.data)
            {
                var name = item.Value<string>("name");
                list.Add(name);
                //list.Add(item.name);//不可直接add
            }

            var error_code = obj.Value<string>("error_code");//此种方式可避免空值引发异常
            var error_code3 = obj["error_code"].ToString();
            var error_code2 = obj["error_code"].Value<string>();
            Console.WriteLine($"三种JObject单层对象解析方式：{Environment.NewLine} error_code:{error_code}{Environment.NewLine}error_code2:{error_code2}{Environment.NewLine}error_code3:{error_code3}");


            var face_token = obj["result"]["face_token"].Value<string>();
            var face_token2 = obj["result"].Value<string>("face_token");
            var face_token3 = ((dynamic)obj).result.face_token;
            Console.WriteLine($"三种JObject双层对象解析方式：{Environment.NewLine} face_token:{face_token}{Environment.NewLine}face_token2:{face_token2}{Environment.NewLine}face_token3:{face_token3}");


            Console.WriteLine("转化成JArray后遍历");
            foreach (var item in obj["result"]["user_list"].Value<JArray>())
            {
                Console.WriteLine($"{item["group_id"].Value<string>()}");
            }
            Console.WriteLine("直接遍历");
            foreach (var item in obj["result"]["user_list"])
            {
                Console.WriteLine($"{item["group_id"].Value<string>()}");
            }
            #endregion



            #region 字典遍历异常情况
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("key1", "value1");
            //try
            //{
            //    if (dic.ContainsKey(null)) //判断指定参数(可能为null)是否包含该键值时会报异常
            //    {
            //        Console.WriteLine("");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //Console.WriteLine(dic["key1"].ToString());
            #endregion



            #region 定时器 Timers.Timer执行时间不精准
            //timer1 = new System.Timers.Timer(1); //设置时间间隔第一次1毫秒，之后更新间隔
            //timer1.Elapsed += Timer_Elapsed;
            //timer1.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            //timer1.Enabled = true; //是否触发Elapsed事件
            //timer1.Start();

            //timer2 = new System.Threading.Timer(new TimerCallback(Callback), new { arg = 1 }, 1 * 1000, 2 * 1000);
            #endregion



            #region 循环遍历删除
            //List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            //for (int i = ints.Count - 1; i >= 0; --i)
            //{
            //    Console.WriteLine($"删除的元素为：{ints[i]}");
            //    ints.Remove(ints[i]);
            //}
            #endregion



            #region 迭代器构建
            //string[] strList = { "Hello", "From", "Tutorials", "Point" };
            //Collection collection = new Collection(strList);
            //foreach (var item in collection)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion



            #region AutoResetEvent Monitor
            //AutoResetEvent autoReset = new AutoResetEvent(false);

            //object monitorObj = new object();
            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        if (autoReset.WaitOne(2000))//等待指定的时间，超时离开。
            //        {
            //            RegularExe(() =>
            //            {
            //                Console.WriteLine(i);
            //            },
            //            ref audioTime);//委托中传值易忽略变量值不变的问题
            //            Console.WriteLine(audioTime.ToString());
            //        }
            //        autoReset.Set();
            //    }
            //for (int i = 0; i < 3; i++)
            //{
            //    if (Monitor.TryEnter(monitorObj, 1000))//尝试在指定的时间内获取锁，超时后不再等待直接离开。
            //    {
            //        Console.WriteLine("1获得对象的排它锁");
            //        Monitor.Exit(monitorObj);
            //        Console.WriteLine("1释放对象的排它锁");
            //    }
            //}
            //});
            //System.Threading.Timer timer1 = new System.Threading.Timer(callback =>
            //{
            //    try
            //    {
            //        if (autoReset.WaitOne(100))
            //        {
            //            Console.WriteLine("收到信号");
            //        }
            //        else
            //        {
            //            Console.WriteLine("未收到信号");
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}, null, 0, 2000);

            //System.Threading.Timer timer2 = new System.Threading.Timer(callback =>
            //{
            //    if (timer2Count < 5)
            //        autoReset.Set();
            //    timer2Count++;
            //}, null, 0, 1500);

            #endregion



            #region SemaphoreSlim（控制并发数量）
            //SemaphoreSlim semaphore = new SemaphoreSlim(4);

            //for (int i = 1; i < 7; i++)
            //{
            //    string threadName = "Thread" + i;
            //    var t = new Thread((() => AccessDatabase(semaphore, threadName, 2)));
            //    t.Start();
            //}

            //#region SemaphoreSlim.WaitAsync() 允许异步同步执行
            //SemaphoreSlim mutex = new SemaphoreSlim(1);
            //for (int i = 0; i < 10; i++)
            //{
            //    UpdateValueAsync(mutex, $"Task{i}");
            //}
            #endregion



            #region CancellationTokenSource
            //CancellationTokenSource cancellationToken1 = new CancellationTokenSource();
            //CancellationTokenSource cancellationToken2 = new CancellationTokenSource();

            //Task.Run(() =>
            //{
            //    while (!cancellationToken1.IsCancellationRequested)
            //    {
            //    }
            //}, cancellationToken1.Token);
            //Console.WriteLine("超时停止方式?");
            //Console.ReadLine();
            //cancellationToken1.CancelAfter(TimeSpan.FromSeconds(3));
            //Console.WriteLine("Task已停止");


            //Task.Run(() =>
            //{
            //    while (!cancellationToken2.IsCancellationRequested)
            //    {
            //    }
            //}, cancellationToken2.Token);
            //Console.WriteLine("Cancel停止方式?");
            //Console.ReadLine();
            //cancellationToken2.Cancel();
            //Console.WriteLine("Task已停止");

            #endregion



            #region task异常捕获
            //Task.Run(() =>
            //{
            //    try
            //    {
            //        Console.WriteLine("异常Task开始执行");
            //        throw new Exception("task有异常");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("捕获到Task异常");
            //    }

            //});

            //throw new Exception();
            #endregion



            #region 匹配时间戳字符串
            //string HEX_REG = @"[0-9a-fA-F]";
            //string GUID_REG = "^(" + HEX_REG + "{8}(-" + HEX_REG + "{4}){3}-" + HEX_REG + "{12})?$";
            //string timeReg = DateTime.Now.ToString("yyyyMMdd");
            //Regex regex = new Regex(GUID_REG);
            //var testStr = "nihao8214D33C-6CFE-4043-83E2-615A1A2B99C8";
            //var timeStr = "nihao20220830165131983";
            ////var res1 = regex.IsMatch(testStr);

            //if (timeStr.Contains(timeReg))
            //{
            //    var index = timeStr.IndexOf(timeReg);
            //}

            //var str1 = "本地20220830183500848.png";
            //var int1 = str1.IndexOf(DateTime.Now.ToString("yyyyMMdd"));
            ////var str2 = str1.Substring(0, str1.IndexOf(DateTime.Now.ToString("yyyyMMdd")));

            //var str3 = "{\"success\":null,\"msg\":null,\"data\":null}";
            //var res1 = JObject.Parse(str3);
            //var res2 = res1["success"].Value<string>();
            //Console.WriteLine(res2 == "null");
            //Console.WriteLine(str1.Substring(0, str1.IndexOf(".")));

            ////DeleteIsRunning(@"D:/绩效自评.png");
            //File.Delete(@"D:/1.png");
            #endregion



            #region params
            //ParamsMethod(1, 2, 3);
            #endregion



            #region Reflect
            //Type type = Type.GetType("ConsoleApp1.CustomClass");
            //dynamic dynamic = Activator.CreateInstance(type);
            //dynamic.Method();
            #endregion



            #region UTC
            //Console.WriteLine($"localTime:{DateTime.Now},ToUniversalTime:{DateTime.Now.ToUniversalTime()},ToLocalTime:{DateTime.Now.ToUniversalTime().ToLocalTime()}");
            #endregion



            #region ContinueWith问题
            //Task.Factory.StartNew(async () =>
            //{
            //    await Task.Run(async () =>
            //    {
            //        await Task.Delay(3000);
            //    });
            //    Console.WriteLine("Task任务——后执行");
            //}).ContinueWith((t) =>
            //{
            //    Console.WriteLine("Task延续任务——先执行");
            //});
            #endregion 总结：StartNew类型的延续任务ContinueWith在遇到await关键字时直接执行。



            #region TaskCompletionSource 实现IO操作
            //Task.Run(async () =>
            //{
            //    var taskCompleteRresult = await DownloadStringAsync(new Uri("https://www.baidu.com"));
            //    Console.WriteLine($"TaskCompletionSource包装的Task执行结果长度：{taskCompleteRresult.Length}");
            //});
            #endregion



            #region 捕获异常
            //try
            //{
            //    Task.Run(() => ThrowExceptionTask());//线程外部无法捕获Task异常
            //}
            //catch (Exception ex)
            //{
            //    // The exception is never caught here!
            //    Console.WriteLine($"捕获到ThrowExceptionTask异常");
            //    throw;
            //}
            //try
            //{
            //    Task.Run(() => ThrowExceptionAsync());//Async void方法无法被捕获异常
            //}
            //catch (Exception ex)
            //{
            //    // The exception is never caught here!
            //    Console.WriteLine($"捕获到ThrowExceptionAsync异常");
            //    throw;
            //}
            #endregion



            #region ConfigureAwait(false) 1，防止死锁2，提高性能
            //DelayAsync();
            #endregion



            #region 通过wps注册表路径打开word
            //string wordPath = @"D:/Test.doc";
            ////string wpsPath = @"D:\软件\Kingsoft\WPS Office\ksolaunch.exe";
            //string wpsPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\wps.exe";
            //RegistryKey appPath = Registry.LocalMachine.OpenSubKey(wpsPath);
            //try
            //{
            //    if (appPath != null)
            //    {
            //        string exePath = appPath.GetValue("").ToString();
            //        if (File.Exists(exePath))
            //        {
            //            if (Process.Start(exePath, wordPath) != null)
            //            {
            //                Console.WriteLine("wps打开文件成功");
            //            }

            //            //通过命令打开wps
            //            //Process myprocess = new Process();
            //            //string param = $"/wps /w /fromksolaunch \"{wordPath}\"";
            //            //ProcessStartInfo startInfo = new ProcessStartInfo(wpsPath, param);
            //            //myprocess.StartInfo = startInfo;
            //            //myprocess.Start();
            //        }
            //        else
            //        {
            //            Console.WriteLine("读取的wps浏览器路径不存在");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("未能从注册表读取wps浏览器路径");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}


            //if (File.Exists(wpsPath))
            //{
            //    Task.Factory.StartNew(() =>
            //    {
            //        Process myprocess = new Process();
            //        string param = $"/wps /w /fromksolaunch \"{wordPath}\"";
            //        ProcessStartInfo startInfo = new ProcessStartInfo(wpsPath, param);
            //        myprocess.StartInfo = startInfo;
            //        myprocess.Start();
            //    });
            //}
            //else
            //{
            //    Console.WriteLine("wps未安装在默认路径");
            //}
            #endregion


            #region 运行bat文件
            //Process proc = new Process();
            //string a = @"D:\软件\GWQOcx\ZNXXJHZDService\ZNXXJHZDService.exe";
            //proc.StartInfo.FileName = a.Replace("ZNXXJHZDService.exe", "run.bat");
            //proc.StartInfo.UseShellExecute = false;//运行时隐藏dos窗口
            //proc.StartInfo.CreateNoWindow = true;//运行时隐藏dos窗口
            //proc.StartInfo.Verb = "runas";//设置该启动动作，会以管理员权限运行进程
            //proc.Start();
            //proc.WaitForExit();
            #endregion



            #region linq + split包含空字符串
            string cbr = "测试005,cs005;测试227,test227;童强-法官,qiangtong2;";
            Console.WriteLine("cbr第一个元素组成的集合：" + string.Join(",", cbr.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0])));
            Console.WriteLine(string.Join("|", cbr.Split(';')));
            foreach (var item in cbr.Split(';'))
            {
                Console.WriteLine("split子元素：" + item + "\n");
            }
            #endregion

            Console.Read();
        }

        #region 方法
        static async Task UpdateValueAsync(SemaphoreSlim mutex, string name)
        {
            Console.WriteLine("{0} 等待被异步执行", name);
            await mutex.WaitAsync().ConfigureAwait(false);
            Console.WriteLine("{0} 允许异步执行", name);
            try
            {
                await Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(2));
                });
            }
            finally
            {
                mutex.Release();
            }
        }
        static void AccessDatabase(SemaphoreSlim semaphore, string name, int seconds)
        {
            Console.WriteLine("{0} 等待访问", name);
            semaphore.Wait();
            Console.WriteLine("{0} 被授予访问权限",
              name);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("{0} 完成了", name);
            semaphore.Release();
            Console.ReadKey();
        }
        private static async Task DelayAsync()
        {
            await Task.Delay(3000).ConfigureAwait(false);
        }
        private static void ThrowExceptionTask()
        {
            throw new Exception();
        }
        private static async void ThrowExceptionAsync()
        {
            throw new Exception();
        }
        public static Task<string> DownloadStringAsync(Uri url)
        {
            var tcs = new TaskCompletionSource<string>();
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            webClient.DownloadStringAsync(url);
            return tcs.Task;
        }

        private static void Callback(object state)
        {
            ++timer2Count;
            Console.WriteLine("Timer2定时器");
            dynamic dynamic = state;
            Console.WriteLine($"Timer传入值：{dynamic.arg}");
            Console.WriteLine($"{DateTime.Now},Timer2定时器,执行{timer2Count}次");
            if (timer2Count == 10)
            {
                timer2.Dispose();
            }
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ++timer1Count;
            if (timer1.Interval == 1)
            {
                timer1.Interval = 1000;
            }
            Console.WriteLine($"{DateTime.Now},Timer1定时器,执行{timer1Count}次");
            if (timer1Count == 20)
            {
                timer1.Dispose();
            }
        }

        private static void RegularExe(Action action, ref DateTime Time)
        {
            action?.Invoke();
            Time = DateTime.Now;
        }

        static void ParamsMethod(params object[] args)
        {
            Console.WriteLine(args[0]);
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

    }
}

public class Collection
{
    private readonly string[] str;

    public Collection(string[] str)
    {
        this.str = str;
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < str.Length; i++)
        {
            yield return str[i];
        }
    }
}
