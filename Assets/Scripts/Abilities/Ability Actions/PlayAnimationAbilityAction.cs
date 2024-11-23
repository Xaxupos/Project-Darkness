using System.Collections;
using UnityEngine;
using Characters;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Ability Actions/Play Ability Animation Action", fileName = "Play Ability Animation Action")]
    public class PlayAnimationAbilityAction : AbilityAction
    {
        public string animationStateName = "";

        public override void PerformAction(Character caster, Character target)
        {
            base.PerformAction(caster, target);
            caster.AnimationController.PlayAnimation(animationStateName);
            
            caster.StartCoroutine(WaitUntilAnimationFinish(caster));
        }

        private IEnumerator WaitUntilAnimationFinish(Character caster)
        {
            yield return new WaitUntil((() =>
                caster.AnimationController.GetCurrentAnimatorStateInfo().IsName(animationStateName)));
            
            while (true)
            {
                var stateInfo = caster.AnimationController.GetCurrentAnimatorStateInfo();
                
                if (!stateInfo.IsName(animationStateName))
                {
                    actionFinished = true;
                    yield break;
                }
                
                if (stateInfo.IsName(animationStateName) && stateInfo.normalizedTime >= 1f)
                {
                    actionFinished = true;
                    yield break;
                }
                yield return null;
            }
        }
    }
}