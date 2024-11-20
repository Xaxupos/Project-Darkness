using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform _spawnedTilesParent;
        [SerializeField] private LevelData _levelData;
    }   
}