using Characters;

namespace Abilities
{
    public class AbilityCastInfo
    {
        public Ability Ability;
        public Character Caster;
        public Character Target;

        public AbilityCastInfo(Ability ability, Character caster, Character target)
        {
            this.Ability = ability;
            this.Caster = caster;
            this.Target = target;
        }
    }   
}