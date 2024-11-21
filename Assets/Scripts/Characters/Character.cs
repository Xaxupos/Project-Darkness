using UnityEngine;

namespace Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterImportantPositions _importantPositions;
        [SerializeField] private CharacterAnimationController _animationController;
    
        public CharacterImportantPositions ImportantPositions => _importantPositions;
        public CharacterAnimationController AnimationController => _animationController;
    }   
}