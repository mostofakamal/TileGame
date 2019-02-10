using System.Collections.Generic;

namespace TileGame
{
    public abstract class BaseGreedyFloodFillStrategy
    {
        
        protected abstract void VisitBoardTile(GameBoard board, int x, int y, string prevColor, string newColor,
            ISet<KeyValuePair<int, int>> visited);

        protected bool CheckBoardBoundary(int x, int y, int boardSize)
        {
            return x >= 0 && x < boardSize && y >= 0 && y < boardSize;
        }
        protected void VisitAllConnectedTiles(GameBoard board, int x, int y, string previousColor, string newColor, ISet<KeyValuePair<int, int>> visited)
        {
            VisitBoardTile(board, x + 1, y, previousColor, newColor, visited);  // East 
            VisitBoardTile(board, x - 1, y, previousColor, newColor, visited);  // West
            VisitBoardTile(board, x, y + 1, previousColor, newColor, visited);  // North 
            VisitBoardTile(board, x, y - 1, previousColor, newColor, visited);  // South
        }

        protected void FindAllConnectedTile(GameBoard board, int x, int y, string newColor, ISet<KeyValuePair<int, int>> visited)
        {
            var originColor = board.Tiles[x, y].Color;   
            VisitBoardTile(board, x, y, originColor, newColor, visited);
        }

    }
}