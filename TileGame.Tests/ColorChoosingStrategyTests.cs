using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TileGame.Tests
{
    [TestClass]
    public class ColorChoosingStrategyTests
    {
        [TestMethod]
        public void Test_GreedyColorChoosingStrategy_GivenABoardWithTiles_CorrectColorPicked()
        {
            // Arrange
            IColorChoosingStrategy greedyColorChoosingStrategy = new GreedyColorChoosingStrategy();
            var gameBoard = new GameBoard(4);
            IPlayer player = new Player(gameBoard);
            player.SetColorChoosingStrategy(greedyColorChoosingStrategy);
            string[,] tileColors =
            {
                {Colors.Blue, Colors.Orange, Colors.Orange, Colors.Orange},
                {Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Yellow},
                {Colors.Yellow, Colors.Orange, Colors.Yellow, Colors.Orange},
                {Colors.Yellow, Colors.Yellow, Colors.Orange, Colors.Orange}
            };

            gameBoard.Initialize(tileColors);

            // Act
            var chosenColor = player.ChooseColor();

            // Assert
            Assert.AreEqual(Colors.Yellow, chosenColor);
        }

        [TestMethod]
        public void Test_GreedyColorChoosingStrategy_GivenAnotherBoardWithTiles_CorrectColorPicked()
        {
            // Arrange
            IColorChoosingStrategy greedyColorChoosingStrategy = new GreedyColorChoosingStrategy();
            var gameBoard = new GameBoard(4);
            IPlayer player = new Player(gameBoard);
            player.SetColorChoosingStrategy(greedyColorChoosingStrategy);
            string[,] tileColors =
            {
                {Colors.Blue, Colors.Orange, Colors.Orange, Colors.Orange},
                {Colors.Blue, Colors.Yellow, Colors.Yellow, Colors.Orange},
                {Colors.Yellow, Colors.Orange, Colors.Yellow, Colors.Orange},
                {Colors.Yellow, Colors.Yellow, Colors.Orange, Colors.Orange}
            };

            gameBoard.Initialize(tileColors);

            // Act
            var chosenColor = player.ChooseColor();

            // Assert
            Assert.AreEqual(Colors.Orange, chosenColor);
        }
    }
}
