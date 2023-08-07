using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace iflytek.Court.Office.Core.Utils
{
    public class StackDo
    {
        ConcurrentQueue<Action> Actions = new ConcurrentQueue<Action>();
        Task CurTask { set; get; }
        object TaskStartBlock = new object();
        int Limit = 2;
        public void Do(Action action)
        {
            //if (Actions.Count >= Limit)
            //{
            //    Actions.TryDequeue(out Action actionOut);
            //}
            Actions.Enqueue(action);
            RunTask();
        }

        void RunTask()
        {
            if (CurTask == null)
            {
                lock (TaskStartBlock)
                {
                    if (CurTask == null)
                    {
                        CurTask = Task.Factory.StartNew(() =>
                        {
                            while (Actions.TryDequeue(out Action action))
                            {
                                action();
                            }
                            CurTask = null;
                        });
                    }
                }
            }
        }
    }
}

