
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TileGame.Tests
{
    [TestClass]
    public class FloodFillStrategyTests
    {
        [TestMethod]
        public void Test_GreedyFloodFillStrategy_GivenABoardWithTiles_BoardFilledWithChosenColor()
        {
            // Arrange
            IFloodFillStrategy floodFillStrategy = new GreedyFloodFillStrategy();
            var board = new GameBoard(4);
            string[,] tileColors =
            {
                {Colors.Blue, Colors.Orange, Colors.Orange, Colors.Orange},
                {Colors.Blue, Colors.Yellow, Colors.Yellow, Colors.Orange},
                {Colors.Yellow, Colors.Orange, Colors.Yellow, Colors.Orange},
                {Colors.Yellow, Colors.Yellow, Colors.Orange, Colors.Orange}
            };
            board.Initialize(tileColors);
            board.SetFillingStrategy(floodFillStrategy);
            
            // Act
            floodFillStrategy.FillTilesWithChosenColor(board, Colors.Yellow);

            // Assert
            Assert.AreEqual(board.Tiles[0, 0].Color, Colors.Yellow);
            Assert.AreEqual(board.Tiles[1, 0].Color, Colors.Yellow);
            Assert.AreEqual(board.Tiles[0, 1].Color, Colors.Orange);
        }

        [TestMethod]
        public void Test_GreedyFloodFillStrategy_GivenAnotherBoardWithTiles_BoardFilledWithChosenColor()
        {
            // Arrange
            IFloodFillStrategy greedyFloodFillStrategy = new GreedyFloodFillStrategy();
            var board = new GameBoard(5);
            string[,] tileColors =
            {
                {Colors.Orange,Colors.Orange,  Colors.Blue, Colors.Orange, Colors.Orange},
                {Colors.Yellow,Colors.Orange,Colors.Blue, Colors.Yellow, Colors.Orange},
                {Colors.Blue,  Colors.Orange,Colors.Blue, Colors.Yellow, Colors.Orange},
                {Colors.Blue,  Colors.Blue,  Colors.Blue, Colors.Orange, Colors.Orange},
                {Colors.Blue,  Colors.Blue,  Colors.Yellow,Colors.Orange, Colors.Orange}
            };
            board.Initialize(tileColors);
            board.SetFillingStrategy(greedyFloodFillStrategy);

            // Act
            greedyFloodFillStrategy.FillTilesWithChosenColor(board, Colors.Blue);

            // Assert
            Assert.AreEqual(board.Tiles[0, 0].Color, Colors.Blue);
            Assert.AreEqual(board.Tiles[0, 1].Color, Colors.Blue);
            Assert.AreEqual(board.Tiles[1, 0].Color, Colors.Yellow);
            Assert.AreEqual(board.Tiles[1, 1].Color, Colors.Blue);
            Assert.AreEqual(board.Tiles[2, 1].Color, Colors.Blue);
            Assert.AreEqual(board.Tiles[4, 2].Color, Colors.Yellow);
        }
    }

}
