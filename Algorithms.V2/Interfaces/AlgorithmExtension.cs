using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.V2.Interfaces
{
    public static class AlgorithmExtension
    {
        /// <summary>  The extension method to get the gcd of two numbers.</summary>
        /// <param name="algorithm">The algorithm to extend.</param>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>The gcd of two values.</returns>
        public static int Calculate(this IAlgorithm algorithm, int first, int second)
        {
            CheckValues(algorithm, first, second);
            return algorithm.Calculate(first, second);
        }

        /// <summary>The extension method to get the gcd of two numbers and required time.</summary>
        /// <param name="algorithm">The algorithm to extend.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <returns>The gcd of two values.</returns>
        public static int Calculate(this IAlgorithm algorithm, int first, int second, out long milliseconds)
        {
            CheckValues(algorithm, first, second);
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
        public static int Calculate(this IAlgorithm algorithm, int first, int second, int third)
        {
            CheckValues(algorithm, first, second, third);
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
            CheckValues(algorithm, first, second, third);
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
            CheckValues(algorithm, numbers);
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
            CheckValues(algorithm, numbers);
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = algorithm.Calculate(numbers);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }


        /// <summary>Checks the values.</summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="numbers">The numbers.</param>
        /// <exception cref="System.ArgumentException">All values cannot be zero
        /// or There should be more than 1 argument.</exception>
        /// <exception cref="System.ArgumentNullException">Algorithm reference cannot be null.</exception>
        private static void CheckValues(IAlgorithm algorithm, params int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                throw new ArgumentException("There should be more than 1 argument.");
            }

            if (algorithm == null)
            {
                throw new ArgumentNullException($"{nameof(algorithm)} is null");
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
