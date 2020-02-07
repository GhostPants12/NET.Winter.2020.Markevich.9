using System;

namespace Algorithms.V1.Interfaces
{
    internal abstract class Algorithm
    {
        public int Calculate(int first, int second)
        {
            return this.Func(first, second);
        }

        public int Calculate(int first, int second, out long milliseconds)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(first, second);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        protected abstract int Func(int first, int second);
    }
}