using System;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.GcdImplementations
{
    internal class EuclideanAlgorithm : Algorithm
    {
        /// <summary>Euclidean algorithm for gcd.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        protected override int Func(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                return 1;
            }

            if (second == 0)
            {
                return Math.Abs(first);
            }

            return this.Func(second, first % second);
        }
    }
}