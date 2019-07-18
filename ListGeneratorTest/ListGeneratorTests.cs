using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using RandomList;

namespace RandomListTest
{
    public class Tests
    {
        [Test]
        public void ListGenerationTest()
        {
            //setup
            const int min = 1;
            const int max = 52;

            var random = new Mock<IRandom>();

            random.Setup(random1 => random1.Random(It.IsAny<int>(), It.IsAny<int>()))
                .Returns<int, int>((minMock, maxMock) =>
                {
                    var r = new Random();
                    return r.Next(minMock, maxMock);
                });

            //act
            var sut = new ListGenerator(random.Object);
            var result = sut.Generate(min, max);

            //asserting efficiency of the algorithm 
            random.Verify(random1 => random1.Random(It.IsAny<int>(), It.IsAny<int>()), Times
                .Exactly(max));

            Assert.AreEqual(result.Count, max);

            //asserting the uniqueness of items in the result
            Assert.AreEqual(result.GroupBy(i => i).Count(), max);

            Assert.AreEqual(result.Min(), min);
            Assert.AreEqual(result.Max(), max);
        }
    }
}