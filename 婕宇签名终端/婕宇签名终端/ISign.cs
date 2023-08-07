using System;
using System.Drawing;
using System.Windows.Forms;

namespace 婕宇签名终端
{
    public interface ISign
    {
        /// <summary>
        /// 打开签名板设备
        /// </summary>
        /// <param name="control">签名预览控件</param>
        /// <param name="successFunc"></param>
        /// <param name="errorFunc"></param>
        void OpenDevice(Control control, Action successFunc, Action<string, Exception> errorFunc);
        /// <summary>
        /// 设置签名完成回调方法（完成签名后，自动关闭设备）
        /// </summary>
        /// <param name="callBack"></param>
        void SetSignCallBack(Action<Image> callBack);
        /// <summary>
        /// 关闭签名板
        /// </summary>
        void CloseDevice();
        /// <summary>
        /// 清空签名板
        /// </summary>
        void Clear();
    }
}
