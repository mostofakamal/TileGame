using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TileGame.Tests
{
    [TestClass]
    public class PlayerAndFloodFIllStrategyTests
    {
        [TestMethod]
        public void Test_PlayerWithColorChoosingStrategyAndFillingStrategy_OK()
        {
            // Arrange
            var gameBoard = new GameBoard(5);
            string[,] tileColors =
            {
                {Colors.Orange,Colors.Orange,  Colors.Blue, Colors.Orange, Colors.Orange},
                {Colors.Yellow,Colors.Orange,Colors.Blue, Colors.Yellow, Colors.Orange},
                {Colors.Blue,  Colors.Orange,Colors.Blue, Colors.Yellow, Colors.Orange},
                {Colors.Blue,  Colors.Blue,  Colors.Blue, Colors.Orange, Colors.Orange},
                {Colors.Blue,  Colors.Blue,  Colors.Yellow,Colors.Orange, Colors.Orange}
            };
            gameBoard.Initialize(tileColors);
            IPlayer player = new Player(gameBoard);
            player.SetColorChoosingStrategy(new GreedyColorChoosingStrategy());

            // Act
            var chosenColor = player.ChooseColor();
            gameBoard.FloodFill(chosenColor);

            // Assert
            Assert.AreEqual(Colors.Blue, chosenColor);
            Assert.IsFalse(gameBoard.AreAllTilesSameColor());
        }
    }
}
