using fdb.Models;
using NUnit.Framework;

namespace fdb.tests.Models
{
    [TestFixture]
    public class BoardTests
    {
        private IBoard _board = new Board(new Square[8, 8]);

      
        [Test]
        public void Move_MoveUp_CurrentLocationIndexDecreases()
        {
            //arrange
            var initialLocation = _board.GetCurrentLocation();

            //act
            _board.Move('U');
            var currentPosition = _board.GetCurrentLocation().PositionY;
            //assert
            Assert.IsTrue( currentPosition == initialLocation.PositionY-1);
        }
        
    }
}
