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
        
        public void PlayAnimation(string animName)
        {
            _animator.CrossFade(animName, 0);
        }
        
        public AnimatorStateInfo GetCurrentAnimatorStateInfo()
        {
            return _animator.GetCurrentAnimatorStateInfo(0);
        }
    }   
}