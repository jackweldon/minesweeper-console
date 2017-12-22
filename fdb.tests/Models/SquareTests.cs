using fdb.Models;
using NUnit.Framework;

namespace fdb.tests.Models
{
    [TestFixture]
    public class SquareTests
    {
        [Test]
        public void ToString_IsHit_ReturnsX()
        {
            //arrange
            var Square = new Square()
            {
                IsHit = true
            };
            //act
            var output = Square.ToString();

            //assert
            Assert.IsTrue(output == "X");
        }

        [Test]
        public void ToString_IsHitAndIsMine_ReturnsB()
        {
            //arrange
            var Square = new Square()
            {
                IsHit = true,
                IsMine = true
            };
            //act
            var output = Square.ToString();

            //assert
            Assert.IsTrue(output == "B");
        }

        [Test]
        public void ToString_IsNotHitAndIsMine_ReturnsO()
        {
            //arrange
            var Square = new Square()
            {
                IsHit = false,
                IsMine = true
            };
            //act
            var output = Square.ToString();

            //assert
            Assert.IsTrue(output == "O");
        }

        [Test]
        public void ToString_IsNotHitIsNotMine_ReturnsO()
        {
            //arrange
            var Square = new Square()
            {
                IsHit = false,
                IsMine = false
            };
            //act
            var output = Square.ToString();

            //assert
            Assert.IsTrue(output == "O");
        }
    }
}
