using UnityEngine;
using VInspector;
using System;

namespace HealthSystem
{
    public class CharacterHealthSystem : MonoBehaviour
    {
        [Header("Parameters")] 
        [ReadOnly] [SerializeField] private float _currentHealth;
        [SerializeField] private float _maxHealth;
        
        [Header("Events")] 
        public Action OnDamageTaken;
        public Action OnDie;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(DamageInfo damageInfo)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - damageInfo.finalDamage);

            OnDamageTaken?.Invoke();
            if (_currentHealth == 0)
            {
                OnDie?.Invoke();
            }
        }
    }   
}