using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TileGame.Tests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void TestGameManager_CreateAndThenStartGame_ReturnsAllStepsWithChosenColors()
        {
            // Arrange
            string[,] tileColors =
            {
                {Colors.Orange,Colors.Orange,  Colors.Blue, Colors.Orange, Colors.Orange},
                {Colors.Yellow,Colors.Orange,Colors.Blue, Colors.Yellow, Colors.Orange},
                {Colors.Blue,  Colors.Orange,Colors.Blue, Colors.Yellow, Colors.Orange},
                {Colors.Blue,  Colors.Blue,  Colors.Blue, Colors.Orange, Colors.Orange},
                {Colors.Blue,  Colors.Blue,  Colors.Yellow,Colors.Orange, Colors.Orange}
            };
            var gameManager = new GameManager(5, tileColors, new GreedyFloodFillStrategy(), new GreedyColorChoosingStrategy());

            // Act
            var chosenColors = gameManager.StartGame();

            // Assert
            Assert.AreEqual(3, chosenColors.Count);
            Assert.AreEqual(Colors.Blue, chosenColors[0]);
            Assert.AreEqual(Colors.Orange, chosenColors[1]);
            Assert.AreEqual(Colors.Yellow, chosenColors[2]);

        }

        [TestMethod]
        public void TestGameManager_CreateAndThenStartAnotherGame_ReturnsAllStepsWithChosenColors()
        {
            // Arrange
            string[,] tileColors =
            {
                {Colors.Orange,Colors.Yellow,Colors.Orange,Colors.Blue,Colors.Orange,Colors.Yellow},
                {Colors.Blue,Colors.Orange,Colors.Blue,Colors.Yellow,Colors.Blue,Colors.Yellow},
                {Colors.Blue,Colors.Blue,Colors.Yellow,Colors.Blue,Colors.Blue,Colors.Blue},
                {Colors.Blue,Colors.Yellow,Colors.Orange,Colors.Blue,Colors.Orange,Colors.Yellow},
                {Colors.Blue,Colors.Yellow,Colors.Orange,Colors.Yellow,Colors.Yellow,Colors.Yellow},
                {Colors.Orange,Colors.Blue,Colors.Orange,Colors.Yellow,Colors.Blue,Colors.Orange}
            };
            var gameManager = new GameManager(6, tileColors, new GreedyFloodFillStrategy(), new GreedyColorChoosingStrategy());

            // Act
            var chosenColors = gameManager.StartGame();

            // Assert
            Assert.AreEqual(6, chosenColors.Count);
            Assert.AreEqual(Colors.Blue, chosenColors[0]);
            Assert.AreEqual(Colors.Yellow, chosenColors[1]);
            Assert.AreEqual(Colors.Blue, chosenColors[2]);
            Assert.AreEqual(Colors.Yellow, chosenColors[3]);
            Assert.AreEqual(Colors.Orange, chosenColors[4]);
            Assert.AreEqual(Colors.Blue, chosenColors[5]);
        }
    }
}
