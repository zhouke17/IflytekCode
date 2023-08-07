namespace WinFormsApp
{
    public static class Extension
    {
        public static async Task<T> Timeout<T>(this Task<T> task, int milliseconds)
        {
            var now = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < now)
            {
                if (task.IsCompleted)
                {
                    return await task;
                }
                await Task.Delay(100);
            }
            return default(T);
        }
    }
}
