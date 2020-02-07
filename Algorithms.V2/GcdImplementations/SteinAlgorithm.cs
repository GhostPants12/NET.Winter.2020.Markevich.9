﻿using System;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.GcdImplementations
{
    public class SteinAlgorithm : IAlgorithm
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

            int firstNumberAbs = Math.Abs(first);
            int secondNumberAbs = Math.Abs(second);
            if (firstNumberAbs == 0)
            {
                return secondNumberAbs;
            }

            if (secondNumberAbs == 0)
            {
                return firstNumberAbs;
            }

            int gcp;
            for (gcp = 0; ((firstNumberAbs | secondNumberAbs) & 1) == 0; ++gcp)
            {
                firstNumberAbs >>= 1;
                secondNumberAbs >>= 1;
            }

            while ((firstNumberAbs & 1) == 0)
            {
                firstNumberAbs >>= 1;
            }

            do
            {
                while ((secondNumberAbs & 1) == 0)
                {
                    secondNumberAbs >>= 1;
                }

                if (firstNumberAbs > secondNumberAbs)
                {
                    int temp = firstNumberAbs;
                    firstNumberAbs = secondNumberAbs;
                    secondNumberAbs = temp;
                }

                secondNumberAbs -= firstNumberAbs;
            }
            while (secondNumberAbs != 0);

            return firstNumberAbs << gcp;
        }
    }
}