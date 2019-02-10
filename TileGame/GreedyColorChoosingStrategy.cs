using System.Collections.Generic;
using System.Linq;

namespace TileGame
{
    public class GreedyColorChoosingStrategy : BaseGreedyFloodFillStrategy, IColorChoosingStrategy
    {
        protected override void VisitBoardTile(GameBoard board, int x, int y, string prevColor,
            string newColor, ISet<KeyValuePair<int, int>> visited)
        {
            if (visited.Contains(new KeyValuePair<int, int>(x, y)))
            {
                return;
            }

            if (!CheckBoardBoundary(x, y, board.Size))
            {
                return;
            }

            if (!(x == 0 && y == 0) && board.Tiles[x, y].Color != prevColor
                                    && !(board.Tiles[x, y].Color == newColor
                                         && !visited.Contains(new KeyValuePair<int, int>(x, y))))
            {
                return;
            }

            visited.Add(new KeyValuePair<int, int>(x, y));
            VisitAllConnectedTiles(board, x, y, prevColor, newColor, visited);
        }
        public string ChooseColor(GameBoard board)
        {
            var tiles = board.Tiles;
            var allChooseAbleColors = GetAllChoosableColors(tiles);
            var colorWiseMaxPossibleConnections = new Dictionary<string, int>();
            HashSet<KeyValuePair<int, int>> visitedPlaces = null;

            foreach (var color in allChooseAbleColors)
            {
                visitedPlaces = new HashSet<KeyValuePair<int, int>>();
                FindAllConnectedTile(board, 0, 0, color, visitedPlaces);
                colorWiseMaxPossibleConnections.Add(color, visitedPlaces.Count);
            }

            var highestPossibleConnectedTileCount = colorWiseMaxPossibleConnections.Max(x => x.Value);
            var colorToPick = colorWiseMaxPossibleConnections
                .Where(x => x.Value == highestPossibleConnectedTileCount).Select(x => x.Key).ToList();
            return colorToPick.Count > 1 ? BreakTieAndChooseColor(tiles, visitedPlaces, colorToPick) : colorToPick.Single();
        }

        private IEnumerable<string> GetAllChoosableColors(Tile[,] tiles)
        {
            var originColor = tiles[0, 0].Color;
            var allChooseAbleColors = tiles.Cast<Tile>()
                .Select(x => x.Color).Distinct()
                .Where(x => !x.Equals(originColor)).ToList();
            return allChooseAbleColors;
        }

        private string BreakTieAndChooseColor(Tile[,] tiles, IEnumerable<KeyValuePair<int, int>> visited,
            ICollection<string> samePossibilityColors)
        {
            foreach (var item in visited)
            {
                if (samePossibilityColors.Contains(tiles[item.Key, item.Value].Color))
                {
                    return tiles[item.Key, item.Value].Color;
                }
            }

            return samePossibilityColors.First();
        }
    }
}