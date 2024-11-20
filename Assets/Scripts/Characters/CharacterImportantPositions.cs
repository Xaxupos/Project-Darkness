using System;
using UnityEngine;
using VInspector;
using Abilities;

namespace Characters
{
    public class CharacterImportantPositions : MonoBehaviour
    {
        [SerializeField] private Vector3 initialFightPosition;
        [SerializeField] private SerializedDictionary<AbilityAction, Transform> _abilitiesPositions;

        public Vector3 InitialFightPosition
        {
            get
            {
                if (initialFightPosition == Vector3.zero)
                    initialFightPosition = transform.position;
                    
                return initialFightPosition;
            }
            set { initialFightPosition = value; }
        }

        public Transform GetPositionForAbilityAction(AbilityAction abilityAction)
        {
            if (_abilitiesPositions.ContainsKey(abilityAction))
                return _abilitiesPositions[abilityAction];
        
            return null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(InitialFightPosition, 1);
        }
    }   
}