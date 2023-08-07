using System;
using System.Threading;

namespace SafeTimer
{
    public class SafeTimer : IDisposable
    {
        #region Fields
        private Timer innerTimer;
        private TimerCallback safeCallback = null;
        private TimerCallback originalCallback = null;
        private int syncPoint;
        private ManualResetEvent originalCallbackCompleteEvent = new ManualResetEvent(true);
        #endregion
        #region Constructors
        public SafeTimer(TimerCallback callback)
        {
            InitializeCallback(callback);
            innerTimer = new Timer(safeCallback);
        }
        public SafeTimer(TimerCallback callback, object state, long dueTime, long period)
        {
            InitializeCallback(callback);
            innerTimer = new Timer(safeCallback, state, dueTime, period);
        }
        public SafeTimer(TimerCallback callback, object state, uint dueTime, uint period)
        {
            InitializeCallback(callback);
            innerTimer = new Timer(safeCallback, state, dueTime, period);
        }
        public SafeTimer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
        {
            InitializeCallback(callback);
            innerTimer = new Timer(safeCallback, state, dueTime, period);
        }
        public SafeTimer(TimerCallback callback, object state, int dueTime, int period)
        {
            InitializeCallback(callback);
            innerTimer = new Timer(safeCallback, state, dueTime, period);
        }
        #endregion
        #region Private methods
        private void InitializeCallback(TimerCallback callback)
        {
            originalCallback = callback;
            safeCallback = new TimerCallback(NonReentryCallback);
        }
        private void NonReentryCallback(object state)
        {
            //set syncPoint to 1 if the original value is 0. syncPoint=1 indicates a method is executing.
            if (Interlocked.CompareExchange(ref syncPoint, 1, 0) == 0)
            {
                originalCallbackCompleteEvent.Reset();
                try
                {
                    originalCallback(state);
                }
                catch { }
                finally
                {
                    originalCallbackCompleteEvent.Set();
                    Interlocked.Exchange(ref syncPoint, 0);
                }
            }
        }
        #endregion
        #region Public methods
        public bool Change(long dueTime, long period)
        {
            return innerTimer.Change(dueTime, period);
        }
        public bool Change(int dueTime, int period)
        {
            return innerTimer.Change(dueTime, period);
        }
        public bool Change(TimeSpan dueTime, TimeSpan period)
        {
            return innerTimer.Change(dueTime, period);
        }
        public bool Change(uint dueTime, uint period)
        {
            return innerTimer.Change(dueTime, period);
        }
        public void Stop()
        {
            innerTimer.Change(Timeout.Infinite, Timeout.Infinite);
            originalCallbackCompleteEvent.WaitOne();
        }
        public bool Stop(int milliseconds)
        {
            innerTimer.Change(Timeout.Infinite, Timeout.Infinite);
            return originalCallbackCompleteEvent.WaitOne(milliseconds);
        }
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            innerTimer.Dispose();
        }
        #endregion
    }
}
