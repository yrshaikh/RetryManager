using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetryManager
{
    public static class RetryManager
    {
        public static void Do(Action action, int retryCount, IRetryDuration retryDuration, IList<Type> supportedExceptions = null)
        {
            int tryAttempt = 0;
            do
            {
                try
                {
                    tryAttempt++;
                    action.Invoke();
                    break;
                }
                catch (Exception ex)
                {
                    if (!supportedExceptions.Contains(ex.GetType()))
                        throw;

                    if (tryAttempt > retryCount)
                        throw;
                }
            }
            while (tryAttempt <= retryCount);
        }
    }
}
