using System;
using System.Collections;
using System.Collections.Generic;
using Script.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Enemy
{
    public class EnemySpawner: MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private List<Transform> _spawnPoinList = new List<Transform>();
        [SerializeField] private float _waitTime;
        private WaitForSeconds _wait;
        private EnemyType _enemyType;
        private void Start()
        {
            _wait = new WaitForSeconds(_waitTime);
            StartCoroutine(SpawnEnemyWithDelay());
        }

        private EnemyType RandomEnemyType()
        {
            int type = Random.Range(0, 3);
            switch (type)
            {
               case 0:
                   return EnemyType.Asteroid;
               case 1:
                   return EnemyType.Commet;
               case 2:
                   return EnemyType.SpaceDebris;
            }
            
            throw new Exception("Enemy type out of range");
        }

        private Vector3 RandomPosition()
        {
            return _spawnPoinList[Random.Range(0, _spawnPoinList.Count)].position;
        }

        public void ClonePrototype()
        {
            EnemyFactory.CreateEnemy(RandomEnemyType(), _playerTransform, RandomPosition());
        }

        private IEnumerator SpawnEnemyWithDelay()
        {
            while (true)
            {
                ClonePrototype();
                yield return _wait;
            }
        }
    }
}