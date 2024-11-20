using UnityEngine;

namespace Tiles
{
    public class TilesManager : MonoBehaviourSingleton<TilesManager>
    {
        [SerializeField] private TilePrefabsDatabase _tilePrefabsDatabase;

        public TilePrefabsDatabase GetTilePrefabsDatabase() => _tilePrefabsDatabase;
    }
}