using System;
using System.Linq;

namespace TileGame
{
    public class GameBoard
    {
        public readonly int Size;
        public Tile[,] Tiles;
        private IFloodFillStrategy _defaultFloodFillStrategy;

        public GameBoard(int n)
        {
            Size = n;
            Tiles = new Tile[n, n];
            _defaultFloodFillStrategy = new GreedyFloodFillStrategy();
        }

        public void SetFillingStrategy(IFloodFillStrategy fillStrategy)
        {
            _defaultFloodFillStrategy = fillStrategy;
        }

        public void Initialize(string[,] tileColors)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Tiles[i, j] = new Tile(tileColors[i, j]);
                }
            }
        }

        public void FloodFill(string color)
        {
            _defaultFloodFillStrategy.FillTilesWithChosenColor(this, color);
        }

        public bool AreAllTilesSameColor()
        {
            return Tiles.Cast<Tile>()
                .All(s => string.Equals(Tiles[0, 0].Color, s.Color, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}