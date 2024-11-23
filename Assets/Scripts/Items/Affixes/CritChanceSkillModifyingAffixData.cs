using UnityEngine;
using Characters;
using Abilities;

namespace Items
{
    [CreateAssetMenu(fileName = "Critical Chance Skill Modifying Affix", menuName = "Scriptable Objects/Items/Affixes/Skill Affixes/Critical Chance Skill Modifying Affix")]
    public class CritChanceSkillModifyingAffixData : SkillModifyingAffixData
    {
        public override void ApplyEffect(Player player, float value)
        {
            player.AbilityController.AddSkilllyModifyingAffixData(this);
        }

        public override void UnapplyEffect(Player player, float value)
        {
            player.AbilityController.RemoveSkilllyModifyingAffixData(this);
        }

        public override void ApplySkillModificator(Player player, AbilityCastInfo castInfo)
        {
            foreach (var item in Player.Instance.playerEquippedItems)
            {
                foreach (var skillAffixOnItem in item.GetItemAffixes())
                {
                    if (skillAffixOnItem.Affix == this)
                    {
                        Player.Instance.CharacterStatistics.GetStatistic(StatisticType.CRIT_CHANCE).UpdateCurrentByValue(skillAffixOnItem.RolledValue/100.0f);
                        castInfo.OnCastFinished += () => Player.Instance.CharacterStatistics.GetStatistic(StatisticType.CRIT_CHANCE).UpdateCurrentByValue(-skillAffixOnItem.RolledValue/100.0f);       
                    }
                }
            }
        }
    }   
}