using System;
using Algorithms.V3.GcdImplementations;
using NUnit.Framework;

namespace NODTestsV3
{
    public class Tests
    {
        #region EuclideanTestsV1


        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        public static int GetGcdByEuclideanV3_With2ValidParameters(int firstNumber, int secondNumber)
        {
            EuclideanAlgorithm euclideanAlgorithm = new EuclideanAlgorithm();
            Algorithm algorithm = new Algorithm(euclideanAlgorithm);
            return algorithm.Calculate(firstNumber, secondNumber);
        }

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        public static int GetGcdByEuclideanV3_With3ValidParameters(int firstNumber, int secondNumber, int thirdNumber)
        {
            EuclideanAlgorithm euclideanAlgorithm = new EuclideanAlgorithm();
            Algorithm algorithm = new Algorithm(euclideanAlgorithm);
            return algorithm.Calculate(firstNumber, secondNumber, thirdNumber);
        }

        [TestCase(1, 1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(1, 123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void GetGcdByEuclideanV3_WithManyValidParameters(int expectedResult, params int[] vs)
        {
            EuclideanAlgorithm euclideanAlgorithm = new EuclideanAlgorithm();
            Algorithm algorithm = new Algorithm(euclideanAlgorithm);
            int result = algorithm.Calculate(vs);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 2, 3, 4, 5, int.MinValue)]
        public void GetGcdByEuclideanV3_WithMinValueParameter_ThrowsOutOfRangeException(params int[] vs) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => new Algorithm(new EuclideanAlgorithm()).Calculate(vs));

        [TestCase(0, 0, 0, 0, 0, 0)]
        public void GetGcdByEuclideanV1_WithAllZeroParameters_ThrowsArgumentException(params int[] vs) =>
            Assert.Throws<ArgumentException>(() => new Algorithm(new EuclideanAlgorithm()).Calculate(vs));


        #endregion

        #region SteinTestsV1


        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        public static int GetGcdBySteinV3_With2ValidParameters(int firstNumber, int secondNumber)
        {
            SteinAlgorithm steinAlgorithm = new SteinAlgorithm();
            Algorithm algorithm = new Algorithm(steinAlgorithm);
            return algorithm.Calculate(firstNumber, secondNumber);
        }

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        public static int GetGcdBySteinV3_With3ValidParameters(int firstNumber, int secondNumber, int thirdNumber)
        {
            SteinAlgorithm steinAlgorithm = new SteinAlgorithm();
            Algorithm algorithm = new Algorithm(steinAlgorithm);
            return algorithm.Calculate(firstNumber, secondNumber, thirdNumber);
        }

        [TestCase(1, 1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(1, 123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void GetGcdBySteinV3_WithManyValidParameters(int expectedResult, params int[] vs)
        {
            SteinAlgorithm steinAlgorithm = new SteinAlgorithm();
            Algorithm algorithm = new Algorithm(steinAlgorithm);
            int result = algorithm.Calculate(vs);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 2, 3, 4, 5, int.MinValue)]
        public void GetGcdBySteinV3_WithMinValueParameter_ThrowsOutOfRangeException(params int[] vs) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => new Algorithm(new SteinAlgorithm()).Calculate(vs));

        [TestCase(0, 0, 0, 0, 0, 0)]
        public void GetGcdBySteinV3_WithAllZeroParameters_ThrowsArgumentException(params int[] vs) =>
            Assert.Throws<ArgumentException>(() => new Algorithm(new SteinAlgorithm()).Calculate(vs));


        #endregion
    }
}