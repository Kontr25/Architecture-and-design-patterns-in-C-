using System;
using System.Collections;
using UnityEngine;

namespace Script.Bullets
{
    public class Bullet: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _bulletRigidbody;
        [SerializeField] private float _shotForce;
        private Transform _parent;
        private WaitForSeconds _wait;
        private Coroutine _shotRoutine;

        public float ShotForce
        {
            get => _shotForce;
            set => _shotForce = value;
        }

        public Rigidbody2D BulletRigidbody
        {
            get => _bulletRigidbody;
            set => _bulletRigidbody = value;
        }

        private void Awake()
        {
            _parent = transform.parent;
        }

        private void OnEnable()
        {
            _wait = new WaitForSeconds(.5f);
            _shotRoutine =  StartCoroutine((DisableObjectWithDelay()));
        }

        private void OnDisable()
        {
            if (_shotRoutine != null)
            {
               StopCoroutine(_shotRoutine);
               _shotRoutine = null; 
            }
            
        }

        private IEnumerator DisableObjectWithDelay()
        {
            transform.rotation = _parent.rotation;
            transform.parent = null;
            _bulletRigidbody.AddForce(_parent.up * _shotForce);
            yield return _wait;
            gameObject.SetActive(false);
            transform.parent = _parent;
        }
    }
}