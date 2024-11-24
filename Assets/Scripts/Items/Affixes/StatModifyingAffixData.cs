using Characters;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Stat Modifying Affix", menuName = "Scriptable Objects/Items/Affixes/Stat Modifying Affix")]
    public class StatModifyingAffixData : AffixData
    {
        public bool OperateOnMaxStatValue;
        public StatisticType StatType;

        public override void ApplyEffect(Player player, float value)
        {
            if(OperateOnMaxStatValue)
                player.CharacterStatistics.GetStatistic(StatType).UpdateMaxByValue(value);
            else
                player.CharacterStatistics.GetStatistic(StatType).UpdateCurrentByValue(value);
        }

        public override void UnapplyEffect(Player player, float value)
        {
            if(OperateOnMaxStatValue)
                player.CharacterStatistics.GetStatistic(StatType).UpdateMaxByValue(-value);
            else
                player.CharacterStatistics.GetStatistic(StatType).UpdateCurrentByValue(-value);
        }

        public override AffixOnItem CreateAffixOnItem(Item item)
        {
            return new AffixOnItem(this, item);
        }
    }
}