using DG.Tweening;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Ability Actions/Move To Initial Position Action", fileName = "Move To Initial Position Action")]
    public class MoveToInitialPositionAction : AbilityAction
    {
        public float moveDuration = 2;
        public Ease moveEase = Ease.OutQuad;
    
        public override void PerformAction(Character caster, Character target)
        {
            base.PerformAction(caster, target);

            Vector3 destinationPosition = caster.ImportantPositions.InitialFightPosition;
            
            caster.transform.DOMove(destinationPosition, moveDuration).SetEase(moveEase).OnComplete(() =>
            {
                actionFinished = true;
            });
        }
    }   
}