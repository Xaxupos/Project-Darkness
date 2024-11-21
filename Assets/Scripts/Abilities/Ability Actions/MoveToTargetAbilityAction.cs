using Characters;
using DG.Tweening;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Ability Actions/Move To Target Ability Action", fileName = "Move To Target Ability Action")]
    public class MoveToTargetAbilityAction : AbilityAction
    {
        public float moveDuration = 2;
        public Ease moveEase = Ease.OutQuad;
        
        public override void PerformAction(Character caster, Character target)
        {
            base.PerformAction(caster, target);
            
            Transform destinationTransform = target.ImportantPositions.GetPositionForAbilityAction(this);

            if (destinationTransform == null)
            {
                actionFinished = true;
                return;
            }
            
            caster.transform.DOMove(destinationTransform.position, moveDuration).SetEase(moveEase).OnComplete(() =>
            {
                actionFinished = true;
            });
        }
    }   
}