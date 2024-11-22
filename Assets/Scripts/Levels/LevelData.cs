using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "Level Data", menuName = "Level Data")]
    public class LevelData : ScriptableObject
    {
        public string LevelName;
    }   
}