using Characters;
using UnityEngine;

namespace Tiles
{
    public class BaseTile : MonoBehaviour, ITile
    {
        public virtual void InitTile()
        {
            
        }

        public virtual void OnTileEnter(Character character)
        {
            Debug.Log($"Tile entered by: {character.name}");
        }
    }   
}