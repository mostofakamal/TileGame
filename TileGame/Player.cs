namespace TileGame
{
    public class Player : IPlayer
    {
        private IColorChoosingStrategy _strategy;
        private readonly GameBoard _board;
        public Player(GameBoard board)
        {
            _board = board;
        }

        public void SetColorChoosingStrategy(IColorChoosingStrategy strategy)
        {
            _strategy = strategy;
        }

        public string ChooseColor()
        {
            return _strategy?.ChooseColor(_board);
        }
    }
}