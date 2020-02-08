using System;
using Algorithms.V1.GcdImplementations;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.StaticClasses
{
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)

        /// <summary> API method to find the GCD by Euclidean method.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        public static int FindGcdByEuclidean(int first, int second)
                    => Gcd(first, second, new EuclideanAlgorithm());

        /// <summary>  API method to find the GCD by Euclidean method and the required time.</summary>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new EuclideanAlgorithm());

        /// <summary>  API method to find the GCD by Euclidean method.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <returns>The gcd of three values.</returns>
        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, new EuclideanAlgorithm());

        /// <summary>  API method to find the GCD by Euclidean method and the required time.</summary>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <returns>The gcd of three values.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new EuclideanAlgorithm());

        /// <summary>   API method to find the GCD by Euclidean method.</summary>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), numbers);

        /// <summary>  API method to find the GCD by Euclidean method and the required time.</summary>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), out milliseconds, numbers);

        /// <summary> API method to find the GCD by Stein method.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        public static int FindGcdByStein(int first, int second)
            => Gcd(first, second, new SteinAlgorithm());

        /// <summary>  API method to find the GCD by Stein method and the required time.</summary>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        public static int FindGcdByStein(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new SteinAlgorithm());

        /// <summary>  API method to find the GCD by Stein method.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <returns>The gcd of three values.</returns>
        public static int FindGcdByStein(int first, int second, int third)
            => Gcd(first, second, third, new SteinAlgorithm());

        /// <summary>  API method to find the GCD by Stein method and the required time.</summary>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <returns>The gcd of three values.</returns>
        public static int FindGcdByStein(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new SteinAlgorithm());

        /// <summary>   API method to find the GCD by Stein method.</summary>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        public static int FindGcdByStein(params int[] numbers)
            => Gcd(new SteinAlgorithm(), numbers);

        /// <summary>  API method to find the GCD by Stein method and the required time.</summary>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        public static int FindGcdByStein(out long milliseconds, params int[] numbers)
            => Gcd(new SteinAlgorithm(), out milliseconds, numbers);

        #endregion

        #region Helper methods

        /// <summary>Calculates the gcd of two values.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="algorithm">The algorithm to find the gcd.</param>
        /// <returns>The gcd of two values.</returns>
        private static int Gcd(int first, int second, Algorithm algorithm)
        {
            CheckValues(first, second);
            return algorithm.Calculate(first, second);
        }

        /// <summary> Calculates the gcd of two values and the required time.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="algorithm">The algorithm to find the gcd.</param>
        /// <returns>The gcd of two values.</returns>
        private static int Gcd(int first, int second, out long milliseconds, Algorithm algorithm)
        {
            CheckValues(first, second);
            return algorithm.Calculate(first, second, out milliseconds);
        }

        /// <summary>Calculates the gcd of three values.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <param name="algorithm">The algorithm to find the gcd.</param>
        /// <returns>The gcd of three values.</returns>
        private static int Gcd(int first, int second, int third, Algorithm algorithm)
        {
            return Gcd(Gcd(first, second, algorithm), third, algorithm);
        }

        /// <summary>Calculates the gcd of three values and the required time.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="algorithm">The algorithm to find the gcd.</param>
        /// <returns>The gcd of three values.</returns>
        private static int Gcd(int first, int second, int third, out long milliseconds, Algorithm algorithm)
        {
            milliseconds = 0;
            long bufMilliseconds = 0;
            int firstStepGcd = Gcd(first, second, out bufMilliseconds, algorithm);
            milliseconds += bufMilliseconds;
            int result = Gcd(firstStepGcd, third, out bufMilliseconds, algorithm);
            milliseconds += bufMilliseconds;
            return result;
        }

        /// <summary>Calculates the gcd of the array of numbers.</summary>
        /// <param name="algorithm">The algorithm to find the gcd.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        private static int Gcd(Algorithm algorithm, params int[] numbers)
        {
            int bufGcd = Gcd(numbers[0], numbers[1], algorithm);
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = Gcd(bufGcd, numbers[i], algorithm);
            }

            return bufGcd;
        }

        /// <summary>Calculates the gcd of the array of numbers and the required time.</summary>
        /// <param name="algorithm">The algorithm to find the gcd.</param>
        /// <param name="milliseconds">The required time in milliseconds.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        private static int Gcd(Algorithm algorithm, out long milliseconds, params int[] numbers)
        {
            milliseconds = 0;
            long bufMilliseconds = 0;
            int bufGcd = Gcd(numbers[0], numbers[1], out bufMilliseconds, algorithm);
            milliseconds += bufMilliseconds;
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = Gcd(bufGcd, numbers[i], out bufMilliseconds, algorithm);
                milliseconds += bufMilliseconds;
            }

            return bufGcd;
        }
        #endregion

        #region CheckValues

        /// <summary>Method to check if the values are correct.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <exception cref="ArgumentOutOfRangeException">One of the values is int.MinValue.</exception>
        /// <exception cref="ArgumentException">Two values cannot be zero at the same time.</exception>
        private static void CheckValues(int first, int second)
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
        #endregion

    }
}