using System.Collections.Generic;
using UnityEngine;
using VInspector;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Ability Data/Ability Audio Visual Data", fileName = "Ability Audio Visual Data")]
    public class AbilityAudioVisualData : ScriptableObject
    {
        [Header("Audio")] 
        public List<AudioClip> InitialCastSounds;
        public List<AudioClip> AnimationEventCasterSounds;
        public List<AudioClip> AnimationEventTargetSounds;
        
        [Header("Particles")]
        public SerializedDictionary<ImportantPosition, ParticleSystem> InitialCasterParticles;
        public SerializedDictionary<ImportantPosition, ParticleSystem> InitialTargetParticles;
        public SerializedDictionary<ImportantPosition, ParticleSystem> AnimationEventCasterParticles;
        public SerializedDictionary<ImportantPosition, ParticleSystem> AnimationEventTargetParticles;
    }
}