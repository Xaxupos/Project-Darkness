using System.Collections.Generic;
using System.Collections;
using Characters;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Ability", fileName = "Ability")]
    public class Ability : ScriptableObject
    {
        public string AbilityName;
        public List<AbilityAction> AbilityActions;

        public void PerformAbility(Character caster, Character target)
        {
            Debug.Log($"Performing Ability {AbilityName} used by caster {caster.name} on target {target.name}");
            caster.StartCoroutine(PerformAbilityCoroutine(caster,target));
        }

        public void EndAbility(Character caster, Character target)
        {
            Debug.Log($"Ending Ability {AbilityName} used by caster {caster.name} on target {target.name}");
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