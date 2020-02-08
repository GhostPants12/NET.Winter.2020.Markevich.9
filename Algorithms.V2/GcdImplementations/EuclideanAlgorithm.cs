using System;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.GcdImplementations
{
    public class EuclideanAlgorithm : IAlgorithm
    {
        /// <summary>Calculates the gcd of two values by Euclidean algorithm.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        /// <exception cref="ArgumentOutOfRangeException">One of the arguments is int.MinValue.</exception>
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

            first = Math.Abs(first);
            second = Math.Abs(second);
            while (second != 0)
            {
                second = first % (first = second);
            }

            return first;
        }
    }
}