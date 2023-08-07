using System;

namespace WpfApp.WordContorl
{
    public interface IWord : IDisposable
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();
        /// <summary>
        /// 设置父容器
        /// </summary>
        /// <param name="hwnd">父容器句柄</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        void SetParent(IntPtr hwnd, int width, int height);
        /// <summary>
        /// 打开word文件
        /// </summary>
        /// <param name="path">文件路径</param>
        void OpenFile(string path);
        /// <summary>
        /// 关闭word文件
        /// </summary>
        void CloseFile(string path);
        /// <summary>
        /// 对word重新布局
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        void Layout(int width, int height);
        /// <summary>
        /// 退出word进程
        /// </summary>
        void Exit();
    }
}
