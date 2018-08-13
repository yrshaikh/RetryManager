namespace RetryManager
{
    public class DefaultRetryDuration : IRetryDuration
    {
        public int GetTimeToWaitInMs()
        {
            // hardcoded to wait for 2 seconds
            return 2000;
        }
    }
}