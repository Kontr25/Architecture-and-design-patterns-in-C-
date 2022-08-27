using Asteroids.Object_Pool;
using Script.Factory;
using UnityEngine;
namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private Transform _playerTransform;
        private void Start()
        {
            EnemyFactory.CreateEnemy(_enemyType, _playerTransform);
        }
    }
}


