using UnityEngine;
using VInspector;
using Abilities;
using Characters;

namespace Development
{
    public class DebugPerformAbility : MonoBehaviour
    {
        public Character caster;
        public Character target;
        public Ability ability;

        [Button]
        public void PerformAbility()
        {
            ability.PerformAbility(caster, target);
        }
    }   
}