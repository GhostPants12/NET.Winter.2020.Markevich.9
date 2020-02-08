using System;
using System.Linq;
using Algorithms.V1.StaticClasses;
using Algorithms.V2.GcdImplementations;
using Algorithms.V2.Interfaces;
using NUnit.Framework;

namespace NODTestsV1_V2
{
    public class Tests
    {
        #region EuclideanTestsV1


        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        public static int GetGcdByEuclideanV1_With2ValidParameters(int firstNumber, int secondNumber) =>
            GCDAlgorithms.FindGcdByEuclidean(firstNumber, secondNumber);

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        public static int GetGcdByEuclideanV1_With3ValidParameters(int firstNumber, int secondNumber, int thirdNumber) => GCDAlgorithms.FindGcdByEuclidean(firstNumber, secondNumber, thirdNumber);

        [TestCase(1, 1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(1, 123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void GetGcdByEuclideanV1_WithManyValidParameters(int expectedResult, params int[] vs)
        {
            int result = GCDAlgorithms.FindGcdByEuclidean(vs);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 2, 3, 4, 5, int.MinValue)]
        public void GetGcdByEuclideanV1_WithMinValueParameter_ThrowsOutOfRangeException(params int[] vs) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GCDAlgorithms.FindGcdByEuclidean(vs));

        [TestCase(0, 0, 0, 0, 0, 0)]
        public void GetGcdByEuclideanV1_WithAllZeroParameters_ThrowsArgumentException(params int[] vs) =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.FindGcdByEuclidean(vs));


        #endregion

        #region SteinTestsV1


        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        public static int GetGcdBySteinV1_With2ValidParameters(int firstNumber, int secondNumber) => GCDAlgorithms.FindGcdByStein(firstNumber, secondNumber);

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        public static int GetGcdBySteinV1_With3ValidParameters(int firstNumber, int secondNumber, int thirdNumber) => GCDAlgorithms.FindGcdByStein(firstNumber, secondNumber, thirdNumber);

        [TestCase(1, 1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(1, 123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void GetGcdBySteinV1_WithManyValidParameters(int expectedResult, params int[] vs)
        {
            int result = GCDAlgorithms.FindGcdByStein(vs);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 2, 3, 4, 5, int.MinValue)]
        public void GetGcdBySteinV1_WithMinValueParameter_ThrowsOutOfRangeException(params int[] vs) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GCDAlgorithms.FindGcdByStein(vs));

        [TestCase(0, 0, 0, 0, 0, 0)]
        public void GetGcdBySteinV1_WithAllZeroParameters_ThrowsArgumentException(params int[] vs) =>
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.FindGcdByStein(vs));


        #endregion

        #region SpeedTests

        [Test]
        public void SpeedTestV1_EuclideanIsFaster()
        {
            int[] arr = Enumerable.Range(1, 100_000).ToArray();
            long euclideanMilliseconds;
            long steinMilliseconds;
            GCDAlgorithms.FindGcdByEuclidean(out euclideanMilliseconds, arr);
            GCDAlgorithms.FindGcdByStein(out steinMilliseconds, arr);
            Assert.IsTrue(steinMilliseconds>euclideanMilliseconds);
        }

        [Test]
        public void SpeedTestV2_EuclideanIsFaster()
        {
            int[] arr = Enumerable.Range(1, 100_000).ToArray();
            long euclideanMilliseconds;
            long steinMilliseconds;
            ((IAlgorithm) (new EuclideanAlgorithm())).Calculate(out euclideanMilliseconds, arr);
            ((IAlgorithm)(new SteinAlgorithm())).Calculate(out steinMilliseconds, arr);
            Assert.IsTrue(steinMilliseconds > euclideanMilliseconds);
        }
        #endregion

        #region EuclideanTestsV2


        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        public static int GetGcdByEuclideanV2_With2ValidParameters(int firstNumber, int secondNumber) =>
            ((IAlgorithm)(new EuclideanAlgorithm())).Calculate(firstNumber, secondNumber);

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        public static int GetGcdByEuclideanV2_With3ValidParameters(int firstNumber, int secondNumber, int thirdNumber) => ((IAlgorithm)(new EuclideanAlgorithm())).Calculate(firstNumber, secondNumber, thirdNumber);

        [TestCase(1, 1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(1, 123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void GetGcdByEuclideanV2_WithManyValidParameters(int expectedResult, params int[] vs)
        {
            int result = ((IAlgorithm)(new EuclideanAlgorithm())).Calculate(vs);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 2, 3, 4, 5, int.MinValue)]
        public void GetGcdByEuclideanV2_WithMinValueParameter_ThrowsOutOfRangeException(params int[] vs) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => ((IAlgorithm)(new EuclideanAlgorithm())).Calculate(vs));

        [TestCase(0, 0, 0, 0, 0, 0)]
        public void GetGcdByEuclideanV2_WithAllZeroParameters_ThrowsArgumentException(params int[] vs) =>
            Assert.Throws<ArgumentException>(() => ((IAlgorithm)(new EuclideanAlgorithm())).Calculate(vs));


        #endregion

        #region SteinTestsV2


        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        public static int GetGcdBySteinV2_With2ValidParameters(int firstNumber, int secondNumber) =>
            ((IAlgorithm)(new SteinAlgorithm())).Calculate(firstNumber, secondNumber);

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        public static int GetGcdBySteinV2_With3ValidParameters(int firstNumber, int secondNumber, int thirdNumber) => ((IAlgorithm)(new SteinAlgorithm())).Calculate(firstNumber, secondNumber, thirdNumber);

        [TestCase(1, 1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(1, 123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void GetGcdBySteinV2_WithManyValidParameters(int expectedResult, params int[] vs)
        {
            int result = ((IAlgorithm)(new SteinAlgorithm())).Calculate(vs);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 2, 3, 4, 5, int.MinValue)]
        public void GetGcdBySteinnV2_WithMinValueParameter_ThrowsOutOfRangeException(params int[] vs) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => ((IAlgorithm)(new SteinAlgorithm())).Calculate(vs));

        [TestCase(0, 0, 0, 0, 0, 0)]
        public void GetGcdBySteinV2_WithAllZeroParameters_ThrowsArgumentException(params int[] vs) =>
            Assert.Throws<ArgumentException>(() => ((IAlgorithm)(new EuclideanAlgorithm())).Calculate(vs));


        #endregion
    }
}