using System.Collections;
using Characters;
using UnityEngine;
using VInspector;

namespace Abilities
{
    public abstract class AbilityAction : ScriptableObject
    {
        [SerializeField] private bool _hasFixedDuration = false;
        [ShowIf("_hasFixedDuration")] [SerializeField] private float _fixedDuration = 0;
        
        protected bool actionFinished = false;
        public bool IsActionFinished => actionFinished;
        public bool HasFixedDuration => _hasFixedDuration;

        public virtual void PerformAction(Character caster, Character target)
        {
            Debug.Log($"Performing action {name} used by caster {caster.name} on target {target.name}");
            actionFinished = false;
            
            if(_hasFixedDuration)
                caster.StartCoroutine(FinishActionByFixedDuration(caster, target));
        }

        private IEnumerator FinishActionByFixedDuration(Character caster, Character target)
        {
            yield return new WaitForSeconds(_fixedDuration);
            actionFinished = true;
        }
    }   
}