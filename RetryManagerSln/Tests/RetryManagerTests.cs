using NUnit.Framework;
using RetryManager;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class RetryManagerTests
    {
        private const int ZERO = 0;

        [Test]
        [TestCase(3, typeof(DivideByZeroException), 3)]
        [TestCase(3, typeof(NullReferenceException), 0)]
        [TestCase(4, typeof(NullReferenceException), 4)]
        public void TestWithRetryCountWorksCorrectly(int retryCount, Type retryOnExceptionType, int expectedResult)
        {
            int input = -1;
            Action action = () =>
            {
                input++;
                int a = input / ZERO;
            };

            try
            {
                RetryManager.RetryManager.Do(
                    action,
                    retryCount,
                    new DefaultRetryDuration(),
                    new List<Type>() { retryOnExceptionType }
                );
            }
            catch (Exception ex)
            {
                Assert.AreEqual(input, expectedResult);
                Assert.AreEqual(ex.GetType(), retryOnExceptionType);
            }
        }
    }
}
