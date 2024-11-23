using Characters;
using System;

namespace Abilities
{
    public class AbilityCastInfo
    {
        public Ability Ability;
        public Character Caster;
        public Character Target;

        public Action OnCastFinished;
        
        public AbilityCastInfo(Ability ability, Character caster, Character target)
        {
            this.Ability = ability;
            this.Caster = caster;
            this.Target = target;
        }
    }   
}