using RetryManager;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RetryManager.RetryManager.Do(
                Work,
                retryCount: 3,
                retryDuration: new DefaultRetryDuration(),
                supportedExceptions: new List<Type> { typeof(DivideByZeroException) }
            );
        }

        private static void Work()
        {
            int a = 0;
            int b = 1;
            int c = b / a;
        }
    }
}
