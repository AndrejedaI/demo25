namespace DemExTest
{
    public static class SafeExecutor
    {
        public static T? TryExecute<T>(Func<T> action, Action<Exception>? onError = null)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
                return default;
            }
        }
    }
}
