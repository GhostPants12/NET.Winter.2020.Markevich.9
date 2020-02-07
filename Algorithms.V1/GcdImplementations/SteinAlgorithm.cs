using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.GcdImplementations
{
    internal class SteinAlgorithm : Algorithm
    {
        protected override int Func(int first, int second)
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
