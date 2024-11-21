using System.Collections.Generic;
using UnityEngine;
using VInspector;
using Abilities;
using System;

namespace Characters
{
    public class CharacterAbilityController : MonoBehaviour
    {
        [Header("References")] 
        public Character owner;
        
        [Header("Debug purposes")] 
        public Character Target;
        
        public Action<AbilityCastInfo> AbilityCasted;
        
        private AbilityCastInfo _currentlyCastingAbility;
        private Character _currentTarget;

        [Button]
        public void UseAbility(Ability ability)
        {
            _currentTarget = Target;
            
            _currentlyCastingAbility = new AbilityCastInfo(ability, owner, _currentTarget);
            
            PlayInitialCastEffects();
            ability.PerformAbility(owner, _currentTarget);
            AbilityCasted?.Invoke(_currentlyCastingAbility);
        }

        public void PlayInitialCastEffects()
        {
            if(_currentlyCastingAbility == null) return;
            
            var abilityData = _currentlyCastingAbility.Ability.abilityAudioVisualData;
            
            PlayAbilityAudioClips(owner, abilityData.InitialCastSounds);
            
            PlayParticlesAtProperPositions(owner, abilityData.InitialCasterParticles);
            PlayParticlesAtProperPositions(_currentTarget, abilityData.InitialTargetParticles);
        }
        
        public void PlayAnimationEventCasterEffects()
        {
            if(_currentlyCastingAbility == null) return;
            
            var abilityData = _currentlyCastingAbility.Ability.abilityAudioVisualData;
            
            PlayAbilityAudioClips(owner, abilityData.AnimationEventCasterSounds);
            
            PlayParticlesAtProperPositions(owner, abilityData.AnimationEventCasterParticles);
        }
        
        public void PlayAnimationEventTargetEffects()
        {
            if(_currentlyCastingAbility == null) return;
            
            var abilityData = _currentlyCastingAbility.Ability.abilityAudioVisualData;

            PlayAbilityAudioClips(_currentTarget, abilityData.AnimationEventTargetSounds);

            PlayParticlesAtProperPositions(_currentTarget, abilityData.AnimationEventTargetParticles);
        }
        
        private void PlayParticlesAtProperPositions(Character characterToPlayOn, SerializedDictionary<ImportantPosition, ParticleSystem> particlesDict)
        {
            foreach (var particleEntry in particlesDict)
            {
                var position = characterToPlayOn.ImportantPositions.GetDesiredPosition(particleEntry.Key);
                var particlePrefab = particleEntry.Value;
                
                var particleInstance = Instantiate(particlePrefab, position, Quaternion.identity);
                particleInstance.transform.SetParent(characterToPlayOn.transform);
                particleInstance.Play();
            }
        }

        private void PlayAbilityAudioClips(Character characterToPlayOn, List<AudioClip> audioClips)
        {
            foreach (var clip in audioClips)
            {
                AudioSource.PlayClipAtPoint(clip, characterToPlayOn.transform.position);
            }
        }

        public void ClearCurrentAbility()
        {
            _currentlyCastingAbility = null;
            _currentTarget = null;
        }
    }   
}