using DG.Tweening;
using UnityEngine;
using Characters;

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
            
            Vector3 destinatedPosition = target.ImportantPositions.GetDesiredPosition(ImportantPosition.ENEMY_MELEE_MOVE);

            if (destinatedPosition == Vector3.zero)
            {
                actionFinished = true;
                return;
            }
            
            caster.transform.DOMove(destinatedPosition, moveDuration).SetEase(moveEase).OnComplete(() =>
            {
                actionFinished = true;
            });
        }
    }   
}