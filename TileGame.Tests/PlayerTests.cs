using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TileGame.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Test_ChoseColor_PlayerChoosesRedColorWhenColorChoosingStrategyReturnsRed()
        {
            // Arrange
            var mockColorChoosingStrategy = new Mock<IColorChoosingStrategy>();
            mockColorChoosingStrategy.Setup(x => x.ChooseColor(It.IsAny<GameBoard>())).Returns(Colors.Red);
            var player = new Player(new GameBoard(3));
            player.SetColorChoosingStrategy(mockColorChoosingStrategy.Object);

            // Act
            var selectedColor = player.ChooseColor();

            // Assert
            Assert.AreEqual(Colors.Red, selectedColor);

        }

        [TestMethod]
        public void Test_ChoseColor_PlayerChoosesGreenColorWhenColorChoosingStrategyReturnsGreen()
        {
            // Arrange
            var mockColorChoosingStrategy = new Mock<IColorChoosingStrategy>();
            mockColorChoosingStrategy.Setup(x => x.ChooseColor(It.IsAny<GameBoard>())).Returns(Colors.Green);
            var player = new Player(new GameBoard(3));
            player.SetColorChoosingStrategy(mockColorChoosingStrategy.Object);

            // Act
            var selectedColor = player.ChooseColor();

            // Assert
            Assert.AreEqual(Colors.Green, selectedColor);

        }

    }
}
