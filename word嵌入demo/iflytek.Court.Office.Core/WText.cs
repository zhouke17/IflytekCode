using iflytek.Court.Office.Core.Interface;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iflytek.Court.Office.Core
{
    public class WText : IText
    {
        public static WText Create(Range range)
        {
            return new WText(range);
        }

        Range TextRange { set; get; }
        public WText(Range range)
        {
            TextRange = range;
        }
        public void AddBookMark(string name)
        {
            TextRange.Document.Bookmarks.Add(name, TextRange);
        }

        public Range Range()
        {
            return TextRange;
        }
    }
}
