using System;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    public class EuclideanAlgorithm : IAlgorithm
    {
        public int Calculate(int first, int second)
        {
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