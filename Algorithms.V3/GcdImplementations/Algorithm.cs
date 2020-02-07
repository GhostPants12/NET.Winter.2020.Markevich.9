using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    public class Algorithm : IAlgorithm
    {
        private readonly IAlgorithm algorithm;

        public Algorithm(IAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }

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

            this.CheckValues(first, second);
            return this.algorithm.Calculate(first, second);
        }

        public int Calculate(int first, int second, out long milliseconds)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(first, second);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        public int Calculate(int first, int second, int third)
        {
            return this.Calculate(this.Calculate(first, second), third);
        }

        public int Calculate(int first, int second, int third, out long milliseconds)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(first, second, third);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        public int Calculate(params int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                throw new ArgumentException("There should be at least 2 arguments");
            }

            int bufGcd = this.algorithm.Calculate(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                bufGcd = this.Calculate(bufGcd, numbers[i]);
            }

            return bufGcd;
        }

        public int Calculate(out long milliseconds, params int[] numbers)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            int result = this.Calculate(numbers);
            startTime.Stop();
            milliseconds = startTime.ElapsedMilliseconds;
            return result;
        }

        private void CheckValues(int first, int second)
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
    }
}
