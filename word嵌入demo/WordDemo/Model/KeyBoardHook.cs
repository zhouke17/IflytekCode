using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static WordDemo.Model.WinApi;

namespace WordDemo.Model
{
    public class KeyBoardHook
    {
        HookProc KeyBoardCallBack;
        HookProc MouseCallBack;
        IntPtr wHwnd;
        public int hKeyboardHook = 0;
        public int hMouseHook = 0;
        public KeyBoardHook(HookProc keyBoardCallBack, HookProc mouseCallBack, IntPtr hwnd)
        {
            KeyBoardCallBack = keyBoardCallBack;
            MouseCallBack = mouseCallBack;
            wHwnd = hwnd;
        }

        public void Open()
        {
            // 安装键盘钩子
            if (hKeyboardHook == 0)
            {

                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyBoardCallBack, wHwnd, 0);
                if (hKeyboardHook == 0)
                {
                    Stop();
                    throw new Exception("安装键盘钩子失败");
                }
                hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseCallBack, wHwnd, 0);
                if (hMouseHook == 0)
                {
                    Stop();
                    throw new Exception("安装鼠标钩子失败");
                }
            }
        }

        public void Stop()
        {
            UnhookWindowsHookEx(hKeyboardHook);
            UnhookWindowsHookEx(hMouseHook);
        }
    }
}
