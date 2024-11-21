using UnityEngine;

namespace Characters
{
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetAnimatorController(RuntimeAnimatorController controller)
        {
            _animator.runtimeAnimatorController = controller;
        }
    
        public void PlayAnimation(AnimationClip clip)
        {
            _animator.CrossFade(clip.name, 0);
        }
    }   
}