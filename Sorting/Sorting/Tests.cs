using System;
using System.Linq;
using NUnit.Framework;

namespace Sorting
{
    [TestFixture]
    public class Tests
    {
        [TestCase(100)]
        public void RightCountArrayInGeneratorArraysTest(long expectedCountArrays)
        {
            var generator = new GeneratorArrays(2, 2, expectedCountArrays);
            var arrays = generator.GenerateArrays();
            Assert.AreEqual(arrays.Length, expectedCountArrays);
        }

        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(200000)]
        [TestCase(3000000)]
        public void RightLengthArrayInGeneratorArraysTest(long expectedLengthArray)
        {
            var generator = new GeneratorArrays(expectedLengthArray, 2, 1);
            var array = generator.GenerateArrays()[0];
            Assert.AreEqual(expectedLengthArray, array.Length);
        }

        [TestCase(10000)]
        [TestCase(400000)]
        [TestCase(900000)]
        public void RightLengthStrInArrayInGeneratorArraysTest(long expectedLengthStr)
        {
            var generator = new GeneratorArrays(1, expectedLengthStr, 1);
            var str = generator.GenerateArrays()[0][0];
            Assert.AreEqual(expectedLengthStr, str.Length);
        }
        
        [Test]
        public void SortTest()
        {
            var expectedArray = new string[] {"a", "b", "c", "d", "e", "f"};
            var unsortedArray = new string[] {"f", "c", "a", "e", "b", "d"};
            var sorter = new Sorter(unsortedArray);
            sorter.Sorted();
            Assert.IsTrue(expectedArray.SequenceEqual(unsortedArray));
        }

        [Test]
        public void ExpectedCountOperationInWorstCase()
        {
            var expectedArray = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l"};
            var unsortedArray = new string[] {"i", "k", "j", "l", "h", "g", "f" ,"a", "d", "c", "b", "e"};
            var sorter = new Sorter(unsortedArray);
            var countOperation = sorter.Sorted();
            Console.Write(countOperation);
            Assert.IsTrue(countOperation <= expectedArray.Length * expectedArray.Length);
        }
    }
}