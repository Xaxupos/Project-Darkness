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
        public Action<AbilityCastInfo> AbilityEventCasterTriggered;
        public Action<AbilityCastInfo> AbilityEventTargetTriggered;
        
        private AbilityCastInfo _currentCastInfo;

        [Button]
        public void UseAbility(Ability ability)
        {
            //replace with target from target selector logics
            _currentCastInfo = new AbilityCastInfo(ability, owner, Target);
            
            PlayInitialCastEffects();
            ability.PerformAbility(_currentCastInfo.Caster, _currentCastInfo.Target);
            AbilityCasted?.Invoke(_currentCastInfo);
        }

        public AbilityCastInfo GetCurrentlyCastingAbility()
        {
            return _currentCastInfo;
        }
        
        public void PlayInitialCastEffects()
        {
            if(_currentCastInfo == null) return;
            
            var audioVisualData = _currentCastInfo.Ability.AbilityAudioVisualData;
            var effectorsData = _currentCastInfo.Ability.AbilityEffectorsData;
            
            PlayAbilityAudioClips(_currentCastInfo.Caster, audioVisualData.InitialCastCasterSounds);
            PlayAbilityAudioClips(_currentCastInfo.Target, audioVisualData.InitialCastTargetSounds);
            
            PlayParticlesAtProperPositions(_currentCastInfo.Caster, audioVisualData.InitialCasterParticles);
            PlayParticlesAtProperPositions(_currentCastInfo.Target, audioVisualData.InitialTargetParticles);

            PlayAbilityEffectors(effectorsData.InitialCastCasterEffectors);
            PlayAbilityEffectors(effectorsData.InitialCastTargetEffectors);
        }
        
        public void PlayAnimationEventCasterEffects()
        {
            if(_currentCastInfo == null) return;
            
            var audioVisualData = _currentCastInfo.Ability.AbilityAudioVisualData;
            var effectorsData = _currentCastInfo.Ability.AbilityEffectorsData;
            
            PlayAbilityAudioClips(_currentCastInfo.Caster, audioVisualData.AnimationEventCasterSounds);
            PlayParticlesAtProperPositions(_currentCastInfo.Caster, audioVisualData.AnimationEventCasterParticles);
            
            PlayAbilityEffectors(effectorsData.AnimationEventCasterEffectors);
            AbilityEventCasterTriggered?.Invoke(_currentCastInfo);
        }
        
        public void PlayAnimationEventTargetEffects()
        {
            if(_currentCastInfo == null) return;
            
            var audioVisualData = _currentCastInfo.Ability.AbilityAudioVisualData;
            var effectorsData = _currentCastInfo.Ability.AbilityEffectorsData;

            PlayAbilityAudioClips(_currentCastInfo.Target, audioVisualData.AnimationEventTargetSounds);
            PlayParticlesAtProperPositions(_currentCastInfo.Target, audioVisualData.AnimationEventTargetParticles);
            
            PlayAbilityEffectors(effectorsData.AnimationEventTargetEffectors);
            AbilityEventTargetTriggered?.Invoke(_currentCastInfo);
        }
        
        public void ClearCurrentAbility()
        {
            _currentCastInfo = null;
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

        private void PlayAbilityEffectors(List<AbilityEffector> abilityEffectors)
        {
            foreach (var abilityEffect in abilityEffectors)
            {
                abilityEffect.ApplyEffector(_currentCastInfo.Caster, _currentCastInfo.Target);
            }
        }
    }   
}