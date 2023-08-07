using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;

namespace iflytek.Court.Office.Core.Models
{
    internal class WordSt
    {
        public string TransformMarkText { set; get; } = "Bk_Transform";
        public ApplicationClass Instance { set; get; }
        /// <summary>
        /// 当前打开的文档
        /// </summary>
        public Document Document { set; get; }
        /// <summary>
        /// word窗口句柄
        /// </summary>
        public IntPtr Hwnd { set; get; }
        /// <summary>
        /// 转写待定的文本Range
        /// </summary>
        public Range TransformRange { set; get; }
        /// <summary>
        /// 转写标记文本Range
        /// </summary>
        public Range MarkRange { set; get; }
        /// <summary>
        /// 转写的文本字体（目前通过读取前一个字符获取颜色）
        /// </summary>
        public Font TransformFont { set; get; }
        /// <summary>
        /// 转写标记字体
        /// </summary>
        public Font MarkFont { set; get; }
        /// <summary>
        /// 是否正在转写
        /// </summary>
        public bool IsTransform { set; get; }
        /// <summary>
        /// 批注列表
        /// </summary>
        public List<CommentSt> Comments { set; get; }
    }
}
