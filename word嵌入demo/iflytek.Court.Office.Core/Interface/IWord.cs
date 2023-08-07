using iflytek.Court.Office.Core.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;

namespace iflytek.Court.Office.Core.Interface
{
    public interface IWord : IDisposable
    {

        /// <summary>
        /// 初始化
        /// </summary>
        void Init();
        void Init(ApplicationClass word);
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
        /// 对word重新布局
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        void Layout(int width, int height);
        /// <summary>
        /// 显示转写标记
        /// </summary>
        void StartTransform(bool isEndOfContent = false);
        /// <summary>
        /// 删除转写标记
        /// </summary>
        void StopTransform();
        /// <summary>
        /// 插入转写语句
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="isnew">是否新语句</param>
        IText InsertTransformText(string text, bool isnew, bool isEnd);

        /// <summary>
        /// 添加批注
        /// </summary>
        /// <param name="start">起始位置</param>
        /// <param name="length">文本长度</param>
        /// <param name="content">批注内容</param>
        /// <param name="author">作者</param>
        IText AddComment(int start, int length, string content, string author);

        /// <summary>
        /// 检查说话人
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IText CheckAndAppendSpeaker(string name);
        /// <summary>
        /// 删除批注
        /// </summary>
        /// <param name="content">批注内容</param>
        void RemoveComment(string content);
        /// <summary>
        /// 删除页脚
        /// </summary>
        void RemoveFooter();
        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pages"></param>
        void InsertSignPages(string path, List<int> pages);
        /// <summary>
        /// 清楚文档中的图片
        /// </summary>
        void RemovePictures();
        /// <summary>
        /// 检查批注是否发生变化
        /// </summary>
        /// <returns></returns>
        ChangeSt CheckCommentChange();
        /// <summary>
        /// 退出word进程
        /// </summary>
        void Exit();
    }
}
