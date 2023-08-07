using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iflytek.Court.Office.Core.Utils
{
    public static class EasyOp
    {
        public static bool TryDo(int tryCount, Action action)
        {
            while (tryCount > 0)
            {
                try
                {
                    action?.Invoke();
                    return true;
                }
                catch (Exception ex)
                {

                }
                tryCount--;
            }
            return false;
        }
    }
}
