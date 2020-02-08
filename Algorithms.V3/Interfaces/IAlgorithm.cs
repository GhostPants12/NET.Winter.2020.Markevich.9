namespace Algorithms.V3.Interfaces
{
    public interface IAlgorithm
    {
        /// <summary>Algorithm to calculate the gcd of two values.</summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The gcd of two values.</returns>
        int Calculate(int first, int second);
    }
}