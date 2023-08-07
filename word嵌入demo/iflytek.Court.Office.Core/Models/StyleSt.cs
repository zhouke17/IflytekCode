using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iflytek.Court.Office.Core.Models
{
    public class StyleSt
    {
        public WdColor Color { set; get; }
        public float Size { set; get; }
        public int Bold { set; get; }
        public string Name { set; get; }
        int start { set; get; }
        int end { set; get; }
        Range oldRange { set; get; }
        public void SaveStyle(Font font, Range range)
        {
            Color = font.Color;
            Size = font.Size;
            Name = font.Name;
            start = range.Start;
            end = range.End;
            oldRange = range; 
        }

        public bool Compare(Font font)
        {
            return Color == font.Color &&
            Size == font.Size &&
            Name == font.Name;
        }

        public bool Compare()
        {
            Range sel = oldRange;
            if (start != end && start == sel.Start && end == sel.End)
            {
                return Compare(sel.Font);
            }
            return true;
        }

        public void SetValue(Font font)
        {
            font.Color = Color;
            font.Size = Size;
            font.Name = Name;
        }
    }
}
