using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    public class SteinAlgorithm : IAlgorithm
    {
        /// <summary>Calculates the gcd of two values by Stein algorithm.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        public int Calculate(int first, int second)
        {
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
