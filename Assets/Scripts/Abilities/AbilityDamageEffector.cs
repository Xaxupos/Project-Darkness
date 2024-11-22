using Characters;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Effectors/Damage Ability Effector", fileName = "Damage Ability Effector")]
    public class DamageAbilityEffector : AbilityEffector
    {
        public float DamageAmount;
        public DamageFlow DamageFlow;

        public override void ApplyEffector(Character caster, Character target)
        {
            if (DamageFlow == DamageFlow.CASTER_TO_TARGET)
            {
                Debug.Log($"{caster.name} dealing {DamageAmount} damage to {target.name}");
            }
            else if (DamageFlow == DamageFlow.TARGET_TO_CASTER)
            {
                Debug.Log($"{target.name} dealing {DamageAmount} damage to {caster.name}");
            }
        }
    }

    public enum DamageFlow
    {
        CASTER_TO_TARGET,
        TARGET_TO_CASTER
    }
}