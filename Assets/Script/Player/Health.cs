using System;
using Script.UI;
using UnityEngine;

namespace Asteroids
{
    public class Health : MonoBehaviour, IHealth
    {
        public float remainingHealth { get; protected set; }
        
        private HealthBar _healthBar;

        public Health(float remainingHealth, HealthBar healthBar)
        {
            this.remainingHealth = remainingHealth;
            _healthBar = healthBar;
            _healthBar.MaxHp = remainingHealth;
        }

        public void HealthUp(float newHp)
        {
            remainingHealth = newHp;
            _healthBar.MaxHp = newHp;
            _healthBar.OnDamaged(this.remainingHealth);
        }

        public void OnDamaged(float remainingHealth)
        {
            if (this.remainingHealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                this.remainingHealth -= remainingHealth;
            }
            _healthBar.OnDamaged(this.remainingHealth);
        }
    }
}
