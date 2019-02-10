using System.Collections.Generic;

namespace TileGame
{
    public class GreedyFloodFillStrategy : BaseGreedyFloodFillStrategy, IFloodFillStrategy
    {
        protected override void VisitBoardTile(GameBoard board, int x, int y, string prevColor, string newColor, ISet<KeyValuePair<int, int>> visited)
        {
            if (!CheckBoardBoundary(x, y, board.Size))
            {
                return;
            }
            var tiles = board.Tiles;
            if (tiles[x, y].Color != prevColor)
            {
                return;
            }

            tiles[x, y].Color = newColor;
            VisitAllConnectedTiles(board, x, y, prevColor, newColor, visited);
        }
       
        public void FillTilesWithChosenColor(GameBoard board, string color)
        {
            FindAllConnectedTile(board, 0, 0, color, new HashSet<KeyValuePair<int, int>>());
        }

    }
}