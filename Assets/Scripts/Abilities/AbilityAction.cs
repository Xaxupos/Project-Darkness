using UnityEngine;

namespace Abilities
{
    public abstract class AbilityAction : ScriptableObject
    {
        protected bool actionFinished = false;
        public bool IsActionFinished => actionFinished;
        
        public abstract void PerformAction(Character caster, Character target);
    }   
}