using UnityEngine;

namespace Tiles
{
    public class TileFactory
    {
        public static ITile CreateTile(TileType tileType, Vector3 position, Transform parent = null)
        {
            if (TilesManager.Instance == null) return null;
        
            GameObject tilePrefab = TilesManager.Instance.GetTilePrefabsDatabase().GetTilePrefab(tileType);
        
            ITile tileInstance = Object.Instantiate(tilePrefab, position, Quaternion.identity, parent).GetComponent<ITile>();
            tileInstance.InitTile();
        
            return tileInstance;
        }
    }   
}