using System.Collections.Generic;
using Asteroids;
using UnityEngine;
using UnityEngine.Serialization;
using DG.Tweening;
using Script.Bullets;

namespace Script.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        private EnemyHealth EnemyHealth { get; set; }
        public Transform MoveTarget { get; set; }

        [FormerlySerializedAs("_speed")] [SerializeField] private float speed;
        [FormerlySerializedAs("_enemyRigidbody")] [SerializeField] private Rigidbody2D enemyRigidbody;
        [SerializeField] private List<GameObject> _listEffect = new List<GameObject>();
        [SerializeField] private float _damage;

        private EnemyMover _enemyMover;
        private EnemyVisualisation _enemyVisualisation;

        private void Start()
        {
            _enemyMover = new EnemyMover(enemyRigidbody, speed);
            _enemyVisualisation = new EnemyVisualisation(_listEffect, transform);
        }

        private void FixedUpdate()
        {
            if(MoveTarget != null)_enemyMover.Move(MoveTarget.position);
        }

        public static Asteroid CreateAsteroidEnemy(EnemyHealth hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.EnemyHealth = hp;
            return enemy;
        }
        
        public void DependencyInjectHealth(EnemyHealth hp)
        {
            EnemyHealth = hp;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player player))
            {
                player.PlayerHealth.OnDamaged(_damage);
                DestroyEnemy();
            }

            if (col.TryGetComponent(out Bullet bullet))
            {
                DestroyEnemy();
            }
        }

        private void DestroyEnemy()
        {
            transform.DOScale(.05f, 0.2f).onComplete = () =>
            {
                _enemyVisualisation.DeathEffect();
                Destroy(gameObject);
            };
        }
    }
}

