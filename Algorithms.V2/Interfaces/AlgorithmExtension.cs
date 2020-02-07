using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.V2.Interfaces
{
    public static class AlgorithmExtension
    {
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

        public static int Calculate(this IAlgorithm algorithm, int first, int second, int third)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException($"{nameof(algorithm)} is null");
            }

            return algorithm.Calculate(algorithm.Calculate(first, second), third);
        }

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
