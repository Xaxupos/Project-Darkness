using UnityEngine;
using Characters;

namespace Items
{
    [System.Serializable]
    public class AffixOnItem
    {
        [field: SerializeField] public Item BindedItem { get; private set; }
        [field: SerializeField] public AffixData Affix { get; private set; }
        [field: SerializeField] public int RolledValue { get; private set; }

        public AffixOnItem(AffixData affix, Item item)
        {
            this.BindedItem = item;
            this.Affix = affix;
            this.RolledValue = Mathf.CeilToInt(Random.Range(affix.AffixRange.x, affix.AffixRange.y));
        }
        
        public void ApplyAffixEffect(Player player, float value)
        {
            Affix.ApplyEffect(player, value);
        }

        public void UnapplyAffixEffect(Player player, float value)
        {
            Affix.UnapplyEffect(player, value);
        }
    }   
}