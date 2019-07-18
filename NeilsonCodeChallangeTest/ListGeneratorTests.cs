using System;
using System.Linq;
using Moq;
using NeilsonCodeChallangeJarre;
using NUnit.Framework;

namespace NeilsonCodeChallangeTest
{
    public class Tests
    {
        [Test]
        public void ListGenerationTest()
        {
            var random = new Mock<IRandom>();

            random.Setup(random1 => random1.Random(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((min, max) =>
            {
                var r = new Random();
                return r.Next(min, max);
            });

            var sut = new ListGenerator(random.Object);
            var result = sut.Generate(1,52);

            //asserting efficiency of the algorithm 
            random.Verify(random1 => random1.Random(It.IsAny<int>(),It.IsAny<int>()),Times.Exactly(52));

            Assert.AreEqual(result.Count, 52);
            //asserting the uniqueness of items in the result
            Assert.AreEqual(result.GroupBy(i => i).Count(), 52);
            Assert.AreEqual(result.Min(), 1);
            Assert.AreEqual(result.Max(), 52);
        }
    }
}