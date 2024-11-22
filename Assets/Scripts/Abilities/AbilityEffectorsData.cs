using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Ability Data/Ability Effectors Data", fileName = "Ability Effectors Data")]
    public class AbilityEffectorsData : ScriptableObject
    {
        [Header("Effects")] 
        public List<AbilityEffector> InitialCastCasterEffectors;
        public List<AbilityEffector> InitialCastTargetEffectors;
        public List<AbilityEffector> AnimationEventCasterEffectors;
        public List<AbilityEffector> AnimationEventTargetEffectors;
    }
}