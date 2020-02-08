using System;

namespace Algorithms.V1.Interfaces
{
    internal abstract class Algorithm
    {
        /// <summary>Calculates the gcd of two values.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        public int Calculate(int first, int second)
        {
            return this.Func(first, second);
        }

        /// <summary>Calculates the gcd of two values and the time to do it.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="milliseconds">The amount of time to calculate the gcd in milliseconds.</param>
        /// <returns>The gcd of two values.</returns>
        public int Calculate(int first, int second, out long milliseconds)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(first, second);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        /// <summary>Function for calculating the gcd of two values.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        protected abstract int Func(int first, int second);
    }
}