using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    public class Algorithm : IAlgorithm
    {
        private readonly IAlgorithm algorithm;

        /// <summary>Initializes a new instance of the <see cref="Algorithm"/> class.</summary>
        /// <param name="algorithm">The algorithm of gcd.</param>
        public Algorithm(IAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        /// <summary>Calculates the gcd of two values.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        public int Calculate(int first, int second)
        {
            this.CheckValues(first, second);
            return this.algorithm.Calculate(first, second);
        }

        /// <summary>Calculates the gcd of two values and the required time.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <returns>The gcd of two values.</returns>
        public int Calculate(int first, int second, out long milliseconds)
        {
            this.CheckValues(first, second);
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(first, second);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        /// <summary>Calculates the gcd of three values.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <returns>The gcd of three values.</returns>
        public int Calculate(int first, int second, int third)
        {
            this.CheckValues(first, second, third);
            return this.algorithm.Calculate(this.algorithm.Calculate(first, second), third);
        }

        /// <summary>Calculates the gcd of three values and the required time.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <returns>The gcd of three values.</returns>
        public int Calculate(int first, int second, int third, out long milliseconds)
        {
            this.CheckValues(first, second, third);
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(first, second, third);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        /// <summary>Calculates the gcd of the array of numbers.</summary>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        public int Calculate(params int[] numbers)
        {
            this.CheckValues(numbers);
            int bufGcd = this.algorithm.Calculate(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = this.algorithm.Calculate(bufGcd, numbers[i]);
            }

            return bufGcd;
        }

        /// <summary>Calculates the gcd of the array of numbers and the required time.</summary>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        public int Calculate(out long milliseconds, params int[] numbers)
        {
            this.CheckValues(numbers);
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(numbers);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }


        /// <summary>Checks the values.</summary>
        /// <param name="numbers">The numbers.</param>
        /// <exception cref="System.ArgumentException">All values cannot be zero
        /// or There should be at least 2 arguments.</exception>
        private void CheckValues(params int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                throw new ArgumentException("There should be more than 1 argument.");
            }

            int zeroCounter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    zeroCounter++;
                }
            }

            if (zeroCounter == numbers.Length)
            {
                throw new ArgumentException("All values cannot be zero");
            }
        }
    }
}
