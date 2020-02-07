using System;
using Algorithms.V1.GcdImplementations;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.StaticClasses
{
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)

        public static int FindGcdByEuclidean(int first, int second)
                    => Gcd(first, second, new EuclideanAlgorithm());

        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new EuclideanAlgorithm());

        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, new EuclideanAlgorithm());

        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new EuclideanAlgorithm());

        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), numbers);

        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), out milliseconds, numbers);

        public static int FindGcdByStein(int first, int second)
            => Gcd(first, second, new SteinAlgorithm());

        public static int FindGcdByStein(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new SteinAlgorithm());

        public static int FindGcdByStein(int first, int second, int third)
            => Gcd(first, second, third, new SteinAlgorithm());

        public static int FindGcdByStein(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new SteinAlgorithm());

        public static int FindGcdByStein(params int[] numbers)
            => Gcd(new SteinAlgorithm(), numbers);

        public static int FindGcdByStein(out long milliseconds, params int[] numbers)
            => Gcd(new SteinAlgorithm(), out milliseconds, numbers);

        #endregion

        #region Helper methods

        private static int Gcd(int first, int second, Algorithm algorithm)
        {
            CheckValues(first, second);
            return algorithm.Calculate(first, second);
        }

        private static int Gcd(int first, int second, out long milliseconds, Algorithm algorithm)
        {
            CheckValues(first, second);
            return algorithm.Calculate(first, second, out milliseconds);
        }

        private static int Gcd(int first, int second, int third, Algorithm algorithm)
        {
            return Gcd(Gcd(first, second, algorithm), third, algorithm);
        }

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

        private static int Gcd(Algorithm algorithm, params int[] numbers)
        {
            int bufGcd = Gcd(numbers[0], numbers[1], algorithm);
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = Gcd(bufGcd, numbers[i], algorithm);
            }

            return bufGcd;
        }

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