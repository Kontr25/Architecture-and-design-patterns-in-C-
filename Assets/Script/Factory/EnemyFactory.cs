using System;
using Asteroids;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.Factory
{
    public static class EnemyFactory
    {
        public static Enemy.Enemy CreateEnemy(EnemyType enemyType, Transform playerTransform, Vector3 spawnPosition)
        {
            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    var asteroid = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"), spawnPosition, Quaternion.identity);
                    asteroid.MoveTarget = playerTransform;
                    return asteroid;
                case  EnemyType.Commet:
                    var commet = Object.Instantiate(Resources.Load<Commet>("Enemy/Commet"), spawnPosition, Quaternion.identity);
                    commet.MoveTarget = playerTransform;
                    return commet;
                case EnemyType.SpaceDebris:
                    var spaceDebris = Object.Instantiate(Resources.Load<SpaceDebris>("Enemy/SpaceDebris"), spawnPosition, Quaternion.identity);
                    spaceDebris.MoveTarget = playerTransform;
                    return spaceDebris;
                default:
                    throw new NotSupportedException();
                    
            }
        }
    }
}