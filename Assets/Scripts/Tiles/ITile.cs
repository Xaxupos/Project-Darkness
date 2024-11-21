using Characters;

namespace Tiles
{
    public interface ITile
    {
        void InitTile();
        void OnTileEnter(Character character);
    }   
}