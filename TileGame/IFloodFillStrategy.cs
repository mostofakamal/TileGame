namespace TileGame
{
    public interface IFloodFillStrategy
    {
        void FillTilesWithChosenColor(GameBoard board, string color);
    }
}