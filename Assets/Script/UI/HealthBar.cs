using System;
using Asteroids;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class HealthBar: MonoBehaviour, IHealth
    {
        public float MaxHp { get; set; }
        
        [SerializeField] private Image _healthBar;
        
        private Transform _followTarget;
        private UIBarMover _uiBarMover;

        public void SetFollowTarget(Transform followTarget)
        {
            _followTarget = followTarget;
            _uiBarMover = new UIBarMover(_followTarget, _healthBar, transform);
        }

        private void Update()
        {
            _uiBarMover.Move();
        }
        
        public float remainingHealth { get; }
        public void OnDamaged(float remainingHealth)
        {
            _healthBar.fillAmount = 1 / MaxHp * remainingHealth;
        }
    }
}