using UnityEngine;

namespace Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterImportantPositions _importantPositions;
        [SerializeField] private CharacterAbilityController _abilityController;
        [SerializeField] private CharacterAnimationController _animationController;
        [SerializeField] private CharacterStatistics _characterStatistics;
    
        public CharacterImportantPositions ImportantPositions => _importantPositions;
        public CharacterStatistics CharacterStatistics => _characterStatistics;
        public CharacterAnimationController AnimationController => _animationController;
        public CharacterAbilityController AbilityController => _abilityController;
    }   
}