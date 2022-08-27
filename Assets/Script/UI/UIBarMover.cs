using System;
using Asteroids;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class UIBarMover: MonoBehaviour
    {
        private Transform _followTarget;
        private Image _healthBar;
        private Transform _uiTransform;

        public UIBarMover(Transform followTarget, Image healthBar, Transform uiTransform)
        {
            _followTarget = followTarget;
            _healthBar = healthBar;
            _uiTransform = uiTransform;
        }
        
        public void Move()
        {
            if (_followTarget != null)
            {
                _uiTransform.position = Vector3.Lerp(
                    _uiTransform.position,
                    new Vector3(_followTarget.position.x, _followTarget.position.y + 4f, _followTarget.position.z), 
                    1000f * Time.deltaTime);
            }
        }
    }
}