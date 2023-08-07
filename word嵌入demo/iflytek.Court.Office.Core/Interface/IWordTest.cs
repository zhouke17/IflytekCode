using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iflytek.Court.Office.Core.Interface
{
    public interface IWordTest
    {
        object GetRange(int start, int end);
        Tuple<int, int> GetRangeValue(object rangeIn);
        void ListenInput();
        void CheckWord(bool isMouse);

        void ReplaceText(string oldText, string newText);
    }
}
