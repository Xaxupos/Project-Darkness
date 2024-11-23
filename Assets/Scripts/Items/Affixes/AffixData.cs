using UnityEngine;
using Characters;
using VInspector;

namespace Items
{
    public abstract class AffixData : ScriptableObject
    {
        public string AffixName;
        [MinMaxSlider(-50, 50)] public Vector2 AffixRange = new Vector2(1, 10);
        
        public abstract void ApplyEffect(Player player, float value);
        public abstract void UnapplyEffect(Player player, float value);

        public virtual AffixOnItem CreateAffixOnItem(Item item)
        {
            return new AffixOnItem(this, item);
        }
    }
}
