using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iflytek.Court.Office.Core.Interface
{
    public interface IText
    {
        void AddBookMark(string name);
        Range Range();
    }
}
