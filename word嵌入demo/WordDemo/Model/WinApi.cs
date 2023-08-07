using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WordDemo.Model
{
    public class WinApi
    {
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        //值在Microsoft SDK的Winuser.h里查询
        public const int WH_KEYBOARD_LL = 13;   //线程键盘钩子监听消息设为2，全局键盘监听消息设为13
        public const int WH_MOUSE_LL = 14; //鼠标钩子
        public const int WH_KEYBOARD = 2;
        public HookProc KeyboardHookProcedure; //声明KeyboardHookProcedure作为HookProc类型
        public const int WM_LBUTTONUP = 0x202;
        //键盘结构
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;  //定一个虚拟键码。该代码必须有一个价值的范围1至254
            public int scanCode; // 指定的硬件扫描码的关键
            public int flags;  // 键标志
            public int time; // 指定的时间戳记的这个讯息
            public int dwExtraInfo; // 指定额外信息相关的信息
        }

        //使用此功能，安装了一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //调用此函数卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //使用此功能，通过信息钩子继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
        //使用此功能，模拟一个按键消息的发出
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);
    }
}
