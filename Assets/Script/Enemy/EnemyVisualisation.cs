using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Script.Enemy
{
    public class EnemyVisualisation: MonoBehaviour
    {
        private List<GameObject> _listEffect = new List<GameObject>();
        private Transform _enemyTransform;
        
        public EnemyVisualisation(List<GameObject> effect, Transform enemyTransform)
        {
            _listEffect = effect;
            _enemyTransform = enemyTransform;
        }

        public void DeathEffect()
        {
            int i = Random.Range(0, _listEffect.Count);
            Instantiate(_listEffect[i], new Vector3(_enemyTransform.position.x, _enemyTransform.position.y, _enemyTransform.position.z - .2f) , Quaternion.identity);
        }
    }
}