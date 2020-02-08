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
        /// <exception cref="ArgumentOutOfRangeException">One of the arguments is int.MinValue.</exception>
        /// <exception cref="ArgumentException">Two values cannot be zero at the same time.</exception>
        public int Calculate(int first, int second)
        {
            if (first == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"{nameof(first)} is int.MinValue.");
            }

            if (second == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"{nameof(second)} is int.MinValue.");
            }

            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Two values cannot be zero at the same time.");
            }

            this.CheckValues(first, second);
            return this.algorithm.Calculate(first, second);
        }

        /// <summary>Calculates the gcd of two values and the required time.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <returns>The gcd of two values.</returns>
        /// <exception cref="ArgumentOutOfRangeException">One of the arguments is int.MinValue.</exception>
        /// <exception cref="ArgumentException">Two values cannot be zero at the same time.</exception>
        public int Calculate(int first, int second, out long milliseconds)
        {
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
            return this.Calculate(this.Calculate(first, second), third);
        }

        /// <summary>Calculates the gcd of three values and the required time.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <returns>The gcd of three values.</returns>
        public int Calculate(int first, int second, int third, out long milliseconds)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(first, second, third);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        /// <summary>Calculates the gcd of the array of numbers.</summary>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        /// <exception cref="ArgumentException">There should be at least 2 numbers in the array.</exception>
        public int Calculate(params int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                throw new ArgumentException("There should be at least 2 arguments");
            }

            int bufGcd = this.algorithm.Calculate(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = this.Calculate(bufGcd, numbers[i]);
            }

            return bufGcd;
        }

        /// <summary>Calculates the gcd of the array of numbers and the required time.</summary>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        /// <exception cref="ArgumentException">There should be at least 2 numbers in the array.</exception>
        public int Calculate(out long milliseconds, params int[] numbers)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(numbers);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        /// <summary>Checks if the values are correct.</summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <exception cref="ArgumentOutOfRangeException">One of the values is int.MinValue.</exception>
        /// <exception cref="ArgumentException">Two values cannot be zero at the same time.</exception>
        private void CheckValues(int first, int second)
        {
            if (first == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"{nameof(first)} is int.MinValue.");
            }

            if (second == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"{nameof(second)} is int.MinValue.");
            }

            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Two values cannot be zero at the same time.");
            }
        }
    }
}
