using UnityEngine;

namespace Abilities
{
    public abstract class AbilityAction : ScriptableObject
    {
        protected bool actionFinished = false;
        public bool IsActionFinished => actionFinished;

        public virtual void PerformAction(Character caster, Character target)
        {
            Debug.Log($"Performing action {name} used by caster {caster.name} on target {target.name}");
            actionFinished = false;
        }
    }   
}