using System.Collections.Generic;

namespace TileGame
{
    public class GameManager : IGameManager
    {
        private readonly GameBoard _gameBoard;
        private readonly IPlayer _player;
        public GameManager(int n, string[,] tileColors, IFloodFillStrategy floodFillStrategy, IColorChoosingStrategy colorChoosingStrategy)
        {
            _gameBoard = new GameBoard(n);
            _gameBoard.Initialize(tileColors);
            _gameBoard.SetFillingStrategy(floodFillStrategy);

            _player = new Player(_gameBoard);
            _player.SetColorChoosingStrategy(colorChoosingStrategy);
        }

        public List<string> StartGame()
        {
            var selectedColorInEachStep = new List<string>();
            while (!_gameBoard.AreAllTilesSameColor())
            {
                var chosenColor = _player.ChooseColor();
                selectedColorInEachStep.Add(chosenColor);
                _gameBoard.FloodFill(chosenColor);
            }

            return selectedColorInEachStep;
        }
    }
}