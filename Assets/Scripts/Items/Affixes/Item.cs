using System.Collections.Generic;
using UnityEngine;
using Characters;
using VInspector;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public List<AffixData> AvailableAffixes;  //later get available affixes for that ItemType for that class from a database instead of manually assigning to each item
        [ReadOnly] [SerializeField] private List<AffixOnItem> _itemAffixes;

        public List<AffixOnItem> GetItemAffixes() => _itemAffixes;
        
        [Button]
        public void GenerateRandomAffixes()
        {
            //later generate based on item rarity, for now let's say the item has always 2 unique affixes
            
            List<AffixData> randomAffixes = new List<AffixData>();
            HashSet<int> selectedIndexes = new HashSet<int>();
            
            while (randomAffixes.Count < 2)
            {
                int randomIndex = Random.Range(0, AvailableAffixes.Count);
                
                if (!selectedIndexes.Contains(randomIndex))
                {
                    selectedIndexes.Add(randomIndex);
                    randomAffixes.Add(AvailableAffixes[randomIndex]);
                }
            }
            
            foreach (var affix in randomAffixes)
            {
                _itemAffixes.Add(affix.CreateAffixOnItem(this));
            }
        }

        [Button]
        public void EquipItem()
        {
            foreach (var affix in _itemAffixes)
            {
                affix.ApplyAffixEffect(Player.Instance, affix.RolledValue);
            }
        }

        [Button]
        public void UnequipItem()
        {
            foreach (var affix in _itemAffixes)
            {
                affix.UnapplyAffixEffect(Player.Instance, affix.RolledValue);
            }
        }
    }   
}