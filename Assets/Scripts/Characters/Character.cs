using Characters;
using UnityEngine;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
    [FormerlySerializedAs("_abilitiesPositions")] [SerializeField] private CharacterImportantPositions importantPositions;
    
    public CharacterImportantPositions ImportantPositions => importantPositions;
}