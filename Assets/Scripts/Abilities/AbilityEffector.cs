using UnityEngine;
using Characters;

namespace Abilities
{
    public abstract class AbilityEffector : ScriptableObject
    {
        public abstract void ApplyEffector(Character caster, Character target);
    }
}