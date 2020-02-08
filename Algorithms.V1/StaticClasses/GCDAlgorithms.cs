using System;
using System.Globalization;
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
            CheckValues(first, second, third);
            return algorithm.Calculate(algorithm.Calculate(first, second), third);
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
            CheckValues(first, second, third);
            milliseconds = 0;
            long bufMilliseconds = 0;
            int firstStepGcd = algorithm.Calculate(first, second, out bufMilliseconds);
            milliseconds += bufMilliseconds;
            int result = algorithm.Calculate(firstStepGcd, third, out bufMilliseconds);
            milliseconds += bufMilliseconds;
            return result;
        }

        /// <summary>Calculates the gcd of the array of numbers.</summary>
        /// <param name="algorithm">The algorithm to find the gcd.</param>
        /// <param name="numbers">The array of numbers.</param>
        /// <returns>The gcd of the array of numbers.</returns>
        private static int Gcd(Algorithm algorithm, params int[] numbers)
        {
            CheckValues(numbers);
            int bufGcd = algorithm.Calculate(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = algorithm.Calculate(bufGcd, numbers[i]);
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
            CheckValues(numbers);
            milliseconds = 0;
            long bufMilliseconds = 0;
            int bufGcd = algorithm.Calculate(numbers[0], numbers[1], out bufMilliseconds);
            milliseconds += bufMilliseconds;
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = algorithm.Calculate(bufGcd, numbers[i], out bufMilliseconds);
                milliseconds += bufMilliseconds;
            }

            return bufGcd;
        }
        #endregion

        #region CheckValues


        /// <summary>Checks the values.</summary>
        /// <param name="values">The values.</param>
        /// <exception cref="System.ArgumentException">All values cannot be zero
        /// or There should be more than 1 argument.</exception>
        private static void CheckValues(params int[] values)
        {
            if (values.Length <= 1)
            {
                throw new ArgumentException("There should be more than 1 argument.");
            }

            int zeroCounter = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    zeroCounter++;
                }
            }

            if (zeroCounter == values.Length)
            {
                throw new ArgumentException("All values cannot be zero");
            }
        }
        #endregion

    }
}