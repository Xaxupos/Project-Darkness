using Characters;
using Abilities;

namespace Items
{
    public abstract class SkillModifyingAffixData : AffixData
    {
        public abstract void ApplySkillModificator(Player characterAbilityController, AbilityCastInfo castInfo);
    }
}