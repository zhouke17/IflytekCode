using Microsoft.Office.Interop.Word;

namespace iflytek.Court.Office.Core.Models
{
    public class ListenRangeSt
    {
        /// <summary>
        /// 标记位置（会实时改变）
        /// </summary>
        public Range Range { set; get; }
        /// <summary>
        /// 缓存的标记位置
        /// </summary>
        public int Start { set; get; }
        public int SelStart { set; get; }
        public int SelEnd { set; get; }
        /// <summary>
        /// Range类型
        /// </summary>
        public RangeType RangeType { set; get; }
        public void Init(Range range, Range selRange, RangeType type = RangeType.Normal)
        {
            Range = range;
            Start = Range.Start;
            RangeType = type;
            SelStart = selRange.Start;
            SelEnd = selRange.End;
        }
    }

    public enum RangeType
    {
        /// <summary>
        /// 正常模式
        /// </summary>
        Normal,
        /// <summary>
        /// 末尾模式
        /// </summary>
        End
    }
}
