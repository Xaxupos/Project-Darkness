using System.Collections.Generic;
using System.Collections;
using Characters;
using UnityEngine;
using UnityEngine.Serialization;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Ability", fileName = "Ability")]
    public class Ability : ScriptableObject
    {
        [Header("Basic Info")]
        public string AbilityName;
        
        [Header("References")]
        public AbilityEffectorsData AbilityEffectorsData;
        public AbilityAudioVisualData AbilityAudioVisualData;
        public List<AbilityAction> AbilityActions;

        public void PerformAbility(Character caster, Character target)
        {
            caster.StartCoroutine(PerformAbilityCoroutine(caster,target));
        }

        public void EndAbility(Character caster, Character target)
        {
            caster.AbilityController.FinishCastingCurrentAbility();
        }
        
        private IEnumerator PerformAbilityCoroutine(Character caster, Character target)
        {
            foreach (var abilityAction in AbilityActions)
            {
                abilityAction.PerformAction(caster, target);
                yield return new WaitUntil(() => abilityAction.IsActionFinished);
            }
            
            EndAbility(caster, target);
        }
    }   
}