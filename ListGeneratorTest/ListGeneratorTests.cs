using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RandomList;

namespace RandomListTest
{
    public class Tests
    {
        [TestCase(1, 10, false)]
        [TestCase(1, 52, false)]
        [TestCase(1, 10, true)]
        [TestCase(1, 52, true)]
        public void ListGenerationTest_not_sorted(int min, int max, bool sorted)
        {
            //setup
            var random = new Mock<IRandom>();

            random.Setup(random1 => random1.Random(It.IsAny<int>(), It.IsAny<int>()))
                .Returns<int, int>((minMock, maxMock) =>
                {
                    var r = new Random();
                    return r.Next(minMock, maxMock);
                });

            //act
            var sut = new ListGenerator(random.Object);
            var result = sut.Generate(min, max, sorted);

            //asserting efficiency of the algorithm 
            random.Verify(random1 => random1.Random(It.IsAny<int>(), It.IsAny<int>()), Times
                .Exactly(max));

            Assert.AreEqual(result.Count, max);

            //asserting the uniqueness of items in the result
            Assert.AreEqual(result.GroupBy(i => i).Count(), max);

            Assert.AreEqual(result.Min(), min);
            Assert.AreEqual(result.Max(), max);

            if (sorted)
                Assert.True(result.SequenceEqual(new List<int>(result.OrderBy(i => i))));
        }
    }
}