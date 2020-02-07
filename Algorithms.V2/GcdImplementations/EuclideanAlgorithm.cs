using System;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.GcdImplementations
{
    public class EuclideanAlgorithm : IAlgorithm
    {
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