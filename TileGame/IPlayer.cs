namespace TileGame
{
    public interface IPlayer
    {
        void SetColorChoosingStrategy(IColorChoosingStrategy strategy);
        string ChooseColor();
    }
}