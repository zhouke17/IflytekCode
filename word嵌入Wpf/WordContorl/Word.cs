using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Reflection;

namespace WpfApp.WordContorl
{
    public class Word : IWord
    {
        private object missing = Missing.Value;

        public ApplicationClass wordApp { set; get; }
        /// <summary>
        /// 当前打开的文档
        /// </summary>
        public Microsoft.Office.Interop.Word.Document Document { set; get; }
        /// <summary>
        /// word窗口句柄
        /// </summary>
        public IntPtr Hwnd { set; get; }

        /// <summary>
        /// 设置父容器
        /// </summary>
        /// <param name="hwnd">父容器句柄</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public void SetParent(IntPtr hwnd, int width, int height)
        {
            Hwnd = WindowApi.FindWindow("OpusApp", null);
            WindowApi.SetParent(Hwnd, hwnd);
            Layout(width, height);
            wordApp.Visible = true;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            wordApp = new ApplicationClass();
        }
        /// <summary>
        /// 退出word进程
        /// </summary>
        public void Exit()
        {
            wordApp?.Quit();
            wordApp = null;
        }

        /// <summary>
        /// 打开word文件
        /// </summary>
        /// <param name="path"></param>
        public void OpenFile(string path)
        {
            object path1 = path;
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.IsReadOnly) fileInfo.IsReadOnly = false;
            Document = wordApp?.Documents?.Open(ref path1, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, true, missing);
            //Document = wordApp?.Documents?.Add(ref path1, missing, missing, true);
        }

        public void CloseFile(string path)
        {
            object path1 = @"D:\1.rtf";
            Document.Save();
            Document.SaveAs(ref path1);
            //wordApp.Visible = false;
            object saveChanges = true;
            Document.Close(ref saveChanges, ref missing, ref missing);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(Document);
            Document = null;
            //wordApp.Quit(ref saveChanges, ref missing, ref missing);
            //System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wordApp);
            //wordApp = null;
        }

        /// <summary>
        /// 对word重新布局
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Layout(int width, int height)
        {
            WindowApi.MoveWindow(Hwnd, 0, 0, width, height, true);
        }


        public void Dispose()
        {
            if (wordApp != null)
                wordApp.Quit();
        }
    }
}
