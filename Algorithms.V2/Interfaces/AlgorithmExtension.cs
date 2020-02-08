using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.V2.Interfaces
{
    public static class AlgorithmExtension
    {
        /// <summary>The extension method to get the gcd of two numbers and required time.</summary>
        /// <param name="algorithm">The algorithm to extend.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <returns>The gcd of two values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when algorithm is null.</exception>
        public static int Calculate(this IAlgorithm algorithm, int first, int second, out long milliseconds)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException($"{nameof(algorithm)} is null");
            }

            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = algorithm.Calculate(first, second);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        /// <summary>The extension method to get the gcd of three numbers.</summary>
        /// <param name="algorithm">The algorithm to extend.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <returns>The gcd of three values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when algorithm is null.</exception>
        public static int Calculate(this IAlgorithm algorithm, int first, int second, int third)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException($"{nameof(algorithm)} is null");
            }

            return algorithm.Calculate(algorithm.Calculate(first, second), third);
        }

        /// <summary>The extension method to get the gcd of three numbers and the required time.</summary>
        /// <param name="algorithm">The algorithm to extend.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <returns>The gcd of three values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when algorithm is null.</exception>
        public static int Calculate(this IAlgorithm algorithm, int first, int second, int third, out long milliseconds)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException($"{nameof(algorithm)} is null");
            }

            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = algorithm.Calculate(first, second, third);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        /// <summary>The extension method to get the gcd of the array of numbers.</summary>
        /// <param name="algorithm">The algorithm to extend.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when algorithm is null.</exception>
        public static int Calculate(this IAlgorithm algorithm, params int[] numbers)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException($"{nameof(algorithm)} is null");
            }

            int bufGcd = algorithm.Calculate(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = algorithm.Calculate(bufGcd, numbers[i]);
            }

            return bufGcd;
        }

        /// <summary>The extension method to get the gcd of the array of numbers and the required time.</summary>
        /// <param name="algorithm">The algorithm to extend.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when algorithm is null.</exception>
        public static int Calculate(this IAlgorithm algorithm, out long milliseconds, params int[] numbers)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException($"{nameof(algorithm)} is null");
            }

            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = algorithm.Calculate(numbers);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }
    }
}
