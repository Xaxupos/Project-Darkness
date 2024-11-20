using UnityEngine;

namespace Tiles
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Databases/Tile Prefabs Database", fileName = "New Tile Prefabs Database")]
    public class TilePrefabsDatabase : ScriptableObject
    {
        public GameObject GetTilePrefab(TileType tileType)
        {
            return null;
        }
    }   
}