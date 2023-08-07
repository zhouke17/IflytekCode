using iflytek.Court.Office.Core.Interface;
using iflytek.Court.Office.Core.Models;
using iflytek.Court.Office.Core.Utils;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace iflytek.Court.Office.Core
{
    public class Word : IWord, IWordTest
    {
        WordSt wordApp { set; get; } = new WordSt();
        private object missing = Missing.Value;

        /// <summary>
        /// 设置父容器
        /// </summary>
        /// <param name="hwnd">父容器句柄</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public void SetParent(IntPtr hwnd, int width, int height)
        {
            wordApp.Hwnd = WindowNativeApi.FindWindow("Opusapp", "Test.doc - WPS 文字 - 兼容模式");
            WindowNativeApi.SetParent(wordApp.Hwnd, hwnd);
            Layout(width, height);
            //WindowNativeApi.SetWindowPos(wordInst.Hwnd, hwnd, 0, 0, width - 20, height - 20, WindowNativeApi.SWP_NOZORDER | WindowNativeApi.SWP_NOMOVE | WindowNativeApi.SWP_DRAWFRAME);
            wordApp.Instance.Visible = true;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            wordApp.Instance = new ApplicationClass()
            {
                //Visible = false,
            };
            //wordApp.MarkFont = new FontClass();
            //wordApp.TransformFont = new FontClass();
            //wordApp.MarkFont.Color = WdColor.wdColorDarkRed;
            wordApp.Comments = new List<CommentSt>();
            wordApp.Instance.WindowSelectionChange += Instance_WindowSelectionChange;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(ApplicationClass word)
        {
            wordApp.Instance = word;
            wordApp.MarkFont = new FontClass();
            wordApp.TransformFont = new FontClass();
            wordApp.MarkFont.Color = WdColor.wdColorDarkRed;
            wordApp.Comments = new List<CommentSt>();
        }

        /// <summary>
        /// 退出word进程
        /// </summary>
        public void Exit()
        {
            wordApp.Instance.Quit();
            wordApp.Instance = null;
        }

        /// <summary>
        /// 打开word文件
        /// </summary>
        /// <param name="path"></param>
        public void OpenFile(string path)
        {
            wordApp.Document = wordApp.Instance.Documents.Open(path);

            foreach (Comment wordComment in wordApp.Document.Comments)
            {
                wordApp.Comments.Add(new CommentSt()
                {
                    Comment = wordComment
                });
            }
            foreach (Bookmark bk in wordApp.Document.Bookmarks)
            {
                if (bk.Name == wordApp.TransformMarkText)
                {
                    bk.Range.Delete();
                }
            }
        }

        /// <summary>
        /// 对word重新布局
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Layout(int width, int height)
        {
            WindowNativeApi.MoveWindow(wordApp.Hwnd, 0, 0, width, height, true);
        }

        /// <summary>
        /// 显示转写标记
        /// </summary>
        public void StartTransform(bool isEndOfContent = false)
        {
            // 先停止转写
            StopTransform();
            Range range = isEndOfContent ? LastCusorPos() : GetSelectionRange(true);
            // 缓存原始字体
            wordApp.TransformFont.Color = range.Font.Color;
            wordApp.TransformFont.Shading.BackgroundPatternColor = range.Font.Shading.BackgroundPatternColor;
            wordApp.MarkRange = range;
            wordApp.MarkRange.Text = "正在转写...";
            wordApp.MarkRange.Font.Color = WdColor.wdColorDarkRed;
            wordApp.MarkRange.Document.Bookmarks.Add(wordApp.TransformMarkText, wordApp.MarkRange);
            wordApp.IsTransform = true;
            Console.WriteLine($"转写标记：start:{wordApp.MarkRange.Start}  end:{wordApp.MarkRange.End}");
        }

        /// <summary>
        /// 删除转写标记
        /// </summary>
        public void StopTransform()
        {
            wordApp.IsTransform = false;
            // 如果上一次转写没完成，则直接清空
            if (wordApp.TransformRange != null)
            {
                wordApp.TransformRange.Delete();
            }
            wordApp.TransformRange = null;
            // 清空之前的转写标记
            if (wordApp.MarkRange != null && wordApp.MarkRange.StoryLength > 0)
            {
                wordApp.MarkRange.Delete();
            }
        }

        /// <summary>
        /// 插入转写语句
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="isnew">是否新语句</param>
        /// <param name="isEnd">是否完整语句</param>
        public IText InsertTransformText(string text, bool isnew, bool isEnd)
        {
            // 跳过未处理完成的数据
            if (wordApp.TransformRange == null && !isnew || !wordApp.IsTransform) return null;

            // 检查标记
            try
            {
                GetAvailableRange(wordApp.MarkRange.End);
                if (wordApp.MarkRange.StoryLength < 2)
                {
                    wordApp.MarkRange = null;
                }
            }
            catch
            {
                wordApp.MarkRange = null;
            }
            if (wordApp.MarkRange == null)
            {
                wordApp.TransformRange = null;
                StartTransform(true);
            }


            if (wordApp.TransformRange == null || isnew)
            {
                if (wordApp.TransformRange != null)
                {
                    wordApp.TransformRange.Font.Shading.BackgroundPatternColor = wordApp.TransformFont.Shading.BackgroundPatternColor;
                }
                wordApp.TransformRange = wordApp.Document.Range(wordApp.MarkRange.Start, wordApp.MarkRange.Start);
            }
            // 直接设置text时，书签会清除
            wordApp.TransformRange.Text = text;
            wordApp.TransformRange.Font.Color = wordApp.TransformFont.Color;
            wordApp.TransformRange.Font.Shading.BackgroundPatternColor = isEnd ? wordApp.TransformFont.Shading.BackgroundPatternColor : WdColor.wdColorLightYellow;

            // 更新标记位置,更新文本，避免文本被修改
            wordApp.MarkRange = wordApp.Document.Range(wordApp.TransformRange.End, wordApp.MarkRange.End);
            wordApp.MarkRange.Text = "正在转写...";
            wordApp.MarkRange.Document.Bookmarks.Add(wordApp.TransformMarkText, wordApp.MarkRange);

            // 返回IText，用于外部添加书签
            var ret = WText.Create(wordApp.TransformRange);

            if (isEnd)
            {
                wordApp.TransformRange = null;
            }
            return ret;
        }

        /// <summary>
        /// 添加批注
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="content"></param>
        /// <param name="author"></param>
        public IText AddComment(int start, int length, string content, string author)
        {
            Range range = length < 0 ? GetSelectionRange() : wordApp.Document.Range(start, start + length);
            Comment comment = range.Document.Comments.Add(range, content);
            comment.Author = author;
            //wordApp.Comments.Add(new CommentSt()
            //{
            //    Comment = comment
            //});
            return WText.Create(range);
        }

        /// <summary>
        /// 删除批注
        /// </summary>
        /// <param name="content">批注内容</param>
        public void RemoveComment(string content)
        {
            for (int i = wordApp.Comments.Count - 1; i >= 0; i--)
            {
                CommentSt item = wordApp.Comments[i];
                if (item.Comment.Range.Text == content)
                {
                    item.Comment.Delete();
                    //wordApp.Comments.Remove(item);
                }
            }
        }

        public void RemoveFooter()
        {
            try
            {
                var hfIndex = Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage;
                Microsoft.Office.Interop.Word.HeaderFooter headerFooter = null;
                for (int i = 1; i < wordApp.Document.Sections.Count + 1; i++)
                {
                    if (wordApp.Document.Sections[i].Footers != null)
                    {
                        headerFooter = wordApp.Document.Sections[i].Footers[hfIndex];
                    }

                    if (headerFooter != null)
                    {
                        headerFooter.Range?.Delete();
                    }
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Microsoft.Office.Interop.Word.Range ftrRng =
            //wordApp.Document.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            //ftrRng.Delete();


            //wordApp.Document.Styles[Word.WdBuiltinStyle.wdStyleNormal].Font.ColorIndex = Word.WdColorIndex.wdBlue;

            //wordApp.Document.Content.Font.ColorIndex = Word.WdColorIndex.wdDarkRed;

            //wordApp.Document.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekPrimaryFooter;
            //wordApp.Document.Application.Selection.MoveRight(WdUnits.wdCharacter, 1);
            //wordApp.Document.Application.Selection.Delete(WdUnits.wdCharacter, 9);
        }
        /// <summary>
        /// 按页码添加签名
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pages"></param>
        public void InsertSignPages(string path, List<int> pages)
        {
            try
            {
                if (wordApp.Document == null) return;
                int pageCount = (int)(wordApp.Document.Range().Information[WdInformation.wdNumberOfPagesInDocument]);
                //We'll hold the start position of each page here
                int pageStart = 0;
                for (int currentPageIndex = 1; currentPageIndex <= pageCount; currentPageIndex++)
                {
                    //This Range object will contain each page.
                    var page = wordApp.Document.Range(pageStart);
                    //Generally, the end of the current page is 1 character before the start of the next.
                    //However, we need to handle the last page -- since there is no next page, the 
                    //GoTo method will move to the *start* of the last page.
                    if (currentPageIndex < pageCount)
                    {
                        //page.GoTo returns a new Range object, leaving the page object unaffected
                        page.End = page.GoTo(
                            What: WdGoToItem.wdGoToPage,
                            Which: WdGoToDirection.wdGoToAbsolute,
                            Count: currentPageIndex + 1
                        ).Start - 1;//本页的最后一个字符的位置
                    }
                    else
                    {
                        page.End = wordApp.Document.Range().End;
                    }
                    pageStart = page.End + 1;//下一页的开始位置
                    if (pages.Contains(currentPageIndex))
                    {
                        try
                        {
                            var local = page.End - 35;
                            var e = page.End - 1;
                            var s = local > 0 && local > page.Start ? local : e > 0 ? e : 0;
                            object range = wordApp.Document.Range(s, s);
                            var shapes = wordApp.Document.InlineShapes.AddPicture(path, ref missing, ref missing, ref range);
                            var shape = shapes.ConvertToShape();
                            shape.Top = wordApp.Document.ActiveWindow.Document.PageSetup.PageHeight - shape.Height - 100;
                            shape.Left = 50;
                            shape.AlternativeText = "签名";
                            shape.WrapFormat.Type = WdWrapType.wdWrapNone;

                            //以下方式将导致无法获取嵌入型的图片对象
                            //shapes.Select();
                            //var shape = shapes.ConvertToShape();
                            //shape.WrapFormat.Type = WdWrapType.wdWrapInline;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RemovePictures()
        {
            foreach (InlineShape shape in wordApp.Document.InlineShapes)
            {
                shape.Delete();
            }
        }
        /// <summary>
        /// 检查批注是否发生变化
        /// </summary>
        /// <returns></returns>
        public ChangeSt CheckCommentChange()
        {
            int changeCount = wordApp.Comments.Where(t => t.IsChanged).Count();
            var comment = wordApp.Comments.Where(t => !t.IsDelete).LastOrDefault();
            int oldCount = wordApp.Comments.Count;
            int curCount = 0;
            DateTime lastDate = comment == null ? DateTime.MinValue : comment.Date;

            int addCount = 0;
            foreach (Comment wordComment in wordApp.Document.Comments)
            {
                curCount++;
                if (lastDate < wordComment.Date)
                {
                    addCount++;
                    wordApp.Comments.Add(new CommentSt() { Comment = wordComment });
                }
            }

            int delCount = wordApp.Comments.Where(t => t.IsDelete).Count();// oldCount + addCount - curCount;

            //Console.WriteLine($"新增数量：{addCount} 删除的数量：{delCount}  发生变化的数量：{changeCount}");
            wordApp.Comments = wordApp.Comments.Where(t => !t.IsDelete).ToList();
            /*
             * 先通过数量检查，判断是否有删除的批注（轮询的话，批注未变动的情况比较多，所以先进行判断）
             * 1.如果有的话，就创建一个新的集合，将新增的和仍存在的塞进去
             * 2.留下的批注就是被删除的
             * 3.删除的批注进行依次删除
             */
            if (changeCount != 0)
            {
                wordApp.Comments.ForEach(t => t.Update());
            }
            return new ChangeSt() { IsChange = (addCount != 0 || delCount != 0 || changeCount != 0), Msg = $"新增数量：{addCount} 删除的数量：{delCount}  发生变化的数量：{changeCount}" };
        }

        /// <summary>
        /// 检查并添加讲话人
        /// </summary>
        /// <param name="name">讲话人</param>
        /// <returns></returns>
        public IText CheckAndAppendSpeaker(string name)
        {
            Range range = wordApp.MarkRange;
            if (range == null)
            {
                return null;
            }
            range = wordApp.Document.Range(range.Paragraphs.First.Range.Start, range.Start);

            string text = range.Text.Trim();
            if (!text.StartsWith(name))
            {
                if (text.Length > 0)
                {
                    // 换行
                    InsertTransformText(text.EndsWith("。") ? "\r\n" : "。\r\n", true, true);
                    return InsertTransformText(name, true, true);
                }
                else
                {
                    return AppendText(range, name);
                }
            }
            return null;
        }

        #region 内部方法

        public void Dispose()
        {
            if (wordApp.Instance != null)
                wordApp.Instance.Quit();
        }

        /// <summary>
        /// 获取选中范围
        /// </summary>
        /// <param name="isCursorPos">是否仅光标位置</param>
        /// <returns></returns>
        private Range GetSelectionRange(bool isCursorPos = false)
        {
            if (isCursorPos)
            {
                int end = wordApp.Instance.Selection.Range.End;
                return wordApp.Document.Range(end, end);
            }
            else
            {
                return wordApp.Instance.Selection.Range;
            }
        }

        private IText AppendText(Range range, string text)
        {
            Range lastRange = GetAvailableRange(range.End);
            lastRange.Text = text;
            return WText.Create(lastRange);
        }

        private Range LastCusorPos()
        {
            int end = wordApp.Document.Paragraphs.Last.Range.End;
            return GetAvailableRange(end);
        }

        private Range GetAvailableRange(int pos)
        {

            try
            {
                return wordApp.Document.Range(pos, pos);
            }
            catch
            {
                return wordApp.Document.Range(pos - 1, pos);
            }
        }
        #endregion

        #region IWordTest接口
        public object GetRange(int start, int end)
        {
            return wordApp.Document.Range(start, end);
        }

        private void Instance_WindowSelectionChange(Selection Sel)
        {
            needUpdate = true;
            needStyleUpdate = true;
            if (Monitor.TryEnter(asyncBlock))
            {
                Monitor.PulseAll(asyncBlock);
                Monitor.Exit(asyncBlock);
            }
            if (Monitor.TryEnter(styleBlock))
            {
                Monitor.PulseAll(styleBlock);
                Monitor.Exit(styleBlock);
            }
        }
        bool needUpdate = false;
        bool needStyleUpdate = false;
        object asyncBlock = new object();
        object styleBlock = new object();
        public Tuple<int, int> GetRangeValue(object rangeIn)
        {
            Range range = rangeIn as Range;
            return new Tuple<int, int>(range.Start, range.End);
        }

        ListenRangeSt ListenRange;
        public void ListenInput()
        {
            UpdateInputRange();
            CheckInputContent();
            CheckStyle();
        }

        void UpdateInputRange(Range selRange = null)
        {
            if (selRange == null)
            {
                selRange = wordApp.Instance.Selection.Range;
            }
            ListenRangeSt temp = new ListenRangeSt();
            Range cRange;
            if (wordApp.Document.Range(selRange.End).End > selRange.End + 1)
            {
                cRange = wordApp.Document.Range(selRange.End + 1, selRange.End + 1);
                temp.Init(cRange, selRange);
            }
            else
            {
                cRange = wordApp.Document.Range(selRange.End, selRange.End);
                temp.Init(cRange, selRange, RangeType.End);
            }
            ListenRange = temp;
            //Console.WriteLine($"重置标志位 {temp.Range.Start}:{temp.Range.End}");
        }

        /// <summary>
        /// word内容变化监听
        /// </summary>
        void CheckInputContent()
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                while (true)
                {

                    bool isEnter = false;
                    while (true)
                    {
                        isEnter = false;
                        try
                        {
                            if (Monitor.TryEnter(asyncBlock))
                            {
                                isEnter = true;
                                // 使用异步锁阻塞循环，在适当的时机由其它线程进行释放并继续后面的逻辑
                                if (Monitor.Wait(asyncBlock))
                                {
                                    int selStart = wordApp.Instance.Selection.Start;
                                    int selEnd = wordApp.Instance.Selection.End;
                                    EditSt ret = DoCheckInputContent(selStart, selEnd);
                                    if (ret.Mode == EditMode.Insert)
                                    {
                                        if (ListenRange.RangeType == RangeType.Normal)
                                        {
                                            /*
                                             * 添加，目前仅支持光标添加，使用光标的End-记录的End，因为是光标，所以Start理论上等于End
                                             */
                                            int length = ret.Length;// Math.Abs(selEnd - ListenRange.End);
                                            string text = wordApp.Document.Range(selEnd - length, selEnd).Text;
                                            Console.WriteLine($"insert curStart:{selStart} length:{length} text:{text}");
                                        }
                                        else
                                        {
                                            int length = ret.Length;// Math.Abs(wordApp.Document.Range(ListenRange.Start).End - ListenRange.Start - 1);
                                            string text = wordApp.Document.Range(selEnd - length, selEnd).Text;
                                            Console.WriteLine($"insert_1 curStart:{selStart} length:{length} text:{text}");
                                        }
                                        break;
                                    }
                                    else if (ret.Mode == EditMode.Delete)
                                    {
                                        if (ListenRange.RangeType == RangeType.Normal)
                                        {
                                            /*
                                             * 删除，包含选中删除和光标删除
                                             * 选中删除，需要使用选中范围的End-当前光标的End
                                             * 光标删除，需要使用记录的End-当前光标的End（此时Start理论上等于End）
                                             */
                                            int length = ret.Length;//Math.Abs(selEnd - ListenRange.End)
                                            Console.WriteLine($"delete curStart:{selStart}  length:{length}");
                                        }
                                        else
                                        {
                                            int length = ret.Length;// Math.Abs(ListenRange.Start - wordApp.Document.Range(selEnd).End - 1);
                                            Console.WriteLine($"delete_1 curStart:{selEnd}  length:{length}");
                                        }
                                        break;
                                    }
                                    else if (ret.Mode == EditMode.Change)
                                    {
                                        string text = wordApp.Document.Range(ListenRange.SelStart, ListenRange.SelStart + ret.NewLength).Text;
                                        Console.WriteLine($"change，RecordStart:{ListenRange.SelStart} {ret.OldLength} -> {ret.NewLength}  text:{text}");
                                        break;
                                    }
                                    else if (needUpdate)
                                    {
                                        break;
                                    }
                                }

                            }
                            if (isEnter)
                                Monitor.Exit(asyncBlock);
                        }
                        catch (Exception ex) { Console.WriteLine("监听已停止"); break; }

                        //System.Threading.Thread.Sleep(1);
                    }
                    if (isEnter)
                        Monitor.Exit(asyncBlock);
                    needUpdate = false;
                    UpdateInputRange();
                }
            });
        }

        /// <summary>
        /// word内容变化检查
        /// </summary>
        /// <param name="selStart"></param>
        /// <param name="selEnd"></param>
        /// <returns></returns>
        EditSt DoCheckInputContent(int selStart, int selEnd)
        {
            if (ListenRange.RangeType == RangeType.Normal)
            {
                if (ListenRange.SelStart == ListenRange.SelEnd)
                {

                    if (ListenRange.Range.Start > ListenRange.Start)
                    {
                        //添加
                        return new EditSt() { Length = ListenRange.Range.Start - ListenRange.Start, Mode = EditMode.Insert };
                    }
                    else if (ListenRange.Range.Start < ListenRange.Start)
                    {
                        // 删除
                        return new EditSt() { Length = ListenRange.Range.Start - ListenRange.Start, Mode = EditMode.Delete };
                    }
                }
                else if (selStart == selEnd)
                {
                    if (ListenRange.Range.Start != ListenRange.Start)
                    {
                        if (ListenRange.SelStart == selEnd)
                        {
                            // 删除
                            return new EditSt() { Length = ListenRange.SelEnd - ListenRange.SelStart, Mode = EditMode.Delete };
                        }
                        else if (ListenRange.SelStart < selEnd)
                        {
                            // 修改
                            int oldLength = ListenRange.SelEnd - ListenRange.SelStart;
                            int newLength = Math.Abs(selEnd - ListenRange.SelStart);
                            return new EditSt() { OldLength = oldLength, NewLength = newLength, Mode = EditMode.Change };
                        }
                    }
                    else
                    {
                        // 这里应该直接判断文本是否发生变化
                    }
                }
            }

            return new EditSt() { Mode = EditMode.None };
        }

        /// <summary>
        /// 释放word内容监听锁，进行word内容及样式检查
        /// </summary>
        /// <param name="isMouse"></param>
        public void CheckWord(bool isMouse)
        {
            if (!isMouse)
            {
                if (Monitor.TryEnter(asyncBlock))
                {
                    Monitor.PulseAll(asyncBlock);
                    Monitor.Exit(asyncBlock);
                }
            }
            if (Monitor.TryEnter(styleBlock))
            {
                Monitor.PulseAll(styleBlock);
                Monitor.Exit(styleBlock);
            }
        }

        StyleSt wordStyle = new StyleSt();

        /// <summary>
        /// 监听word内容样式，仅需调用一次，里面死循环，使用异步锁
        /// </summary>
        void CheckStyle()
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (Monitor.TryEnter(styleBlock))
                    {
                        Monitor.Wait(styleBlock);
                        ChangeSt result = CheckCommentChange();
                        if (result.IsChange)
                        {
                            Console.WriteLine(result.Msg);
                        }
                        if (needStyleUpdate)
                        {
                            wordStyle.SaveStyle(wordApp.Instance.Selection.Font, wordApp.Instance.Selection.Range);
                        }
                        if (!wordStyle.Compare())
                        {
                            wordStyle.SaveStyle(wordApp.Instance.Selection.Font, wordApp.Instance.Selection.Range);
                            string json = JsonConvert.SerializeObject(wordStyle);
                            Console.WriteLine($"新文本样式：{wordApp.Instance.Selection.Font.Color}{json}");
                        }
                        needStyleUpdate = false;
                        Monitor.Exit(styleBlock);
                    }
                }
            });
        }

        public void ChangeComment(string content, int index)
        {
            wordApp.Document.Comments[index].Range.Text = content;
        }

        public void ReplaceText(string oldText, string newText)
        {
            foreach (Paragraph paragraph in wordApp.Document.Paragraphs)
            {
                // 段落的Range
                Range range = paragraph.Range;
                int indexOf = range.Text.IndexOf(oldText);
                while (indexOf >= 0)
                {
                    // 获取实际start位置
                    int start = indexOf + range.Start;
                    // 获取匹配位置的range
                    Range newRange = wordApp.Document.Range(start, range.End);
                    // 再次校准位置
                    int nIndexOf = newRange.Text.IndexOf(oldText);
                    if (nIndexOf < 0)
                    {
                        // 校准失败
                        break;
                    }
                    else if (nIndexOf == 0)
                    {
                        // 无需校准，替换文本
                        int end = newRange.Start + oldText.Length;
                        Range replaceRange = wordApp.Document.Range(newRange.Start, end);
                        replaceRange.Text = newText;
                        break;
                    }
                    else
                    {
                        // 校准位置
                        indexOf = indexOf + nIndexOf;
                    }
                }
            }

        }
        #endregion
    }

    public struct EditSt
    {
        public EditMode Mode { set; get; }
        public int Length { set; get; }
        public int OldLength { set; get; }
        public int NewLength { set; get; }
    }

    public enum EditMode
    {
        Insert,
        Delete,
        Change,
        None
    }
}
