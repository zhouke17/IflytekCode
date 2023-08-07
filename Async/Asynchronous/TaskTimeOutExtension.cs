namespace AsynChronous
{
    public static class TaskTimeOut
    {
        public static async Task<TResult?> TimeoutAfter<TResult>(this Task<TResult?> task, TimeSpan timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return await task;  // Very important in order to propagate exceptions
                }
                else
                {
                    return default(TResult);
                }
            }
        }

        // 无返回值
        public static async Task TimeoutAfter(this Task task, TimeSpan timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    await task;  // Very important in order to propagate exceptions
                }
                else
                {
                    await Task.FromResult(-1);
                }
            }
        }

    }

    public class TaskTimeOut<T1, T> where T1 : class
    {
        Dictionary<T1, TaskCompletionSource<T>> TaskDict = new Dictionary<T1, TaskCompletionSource<T>>();
        /// <summary>
        /// 等待请求-默认5s超时
        /// </summary>
        /// <param name="token">请求的token</param>
        /// <param name="action">等待前执行的方法</param>
        /// <returns></returns>
        public async Task<T> Wait(T1 token, Action action = null)
        {
            return await Wait(token, action, TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 等待请求
        /// </summary>
        /// <param name="token">请求的token</param>
        /// <param name="action">等待前执行的方法</param>
        /// <param name="timeOut">超时时间</param>
        /// <returns></returns>
        public async Task<T> Wait(T1 token, Action action, TimeSpan timeOut)
        {
            TaskCompletionSource<T> taskCompletionSource = new TaskCompletionSource<T>();
            TaskDict.Add(token, taskCompletionSource);
            action?.Invoke();
            try
            {
                T ret = await taskCompletionSource.Task.WaitAsync(timeOut);
                return ret;
            }
            catch
            {
                // 如果超时，则移除字典中的任务
                if (TaskDict.ContainsKey(token))
                {
                    TaskDict.Remove(token);
                }
                throw;
            }
        }

        /// <summary>
        /// 请求完成，触发回调
        /// </summary>
        /// <param name="token">请求的token</param>
        /// <param name="data">返回的数据</param>
        public void Finish(T1 token, T data)
        {
            if (TaskDict.ContainsKey(token))
            {
                TaskDict[token].SetResult(data);
                TaskDict.Remove(token);
            }
        }
    }
}
