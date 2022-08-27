using System;
using Asteroids;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.Factory
{
    public static class EnemyFactory
    {
        public static Enemy.Enemy CreateEnemy(EnemyType enemyType, Transform playerTransform)
        {
            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    var asteroid = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
                    asteroid.MoveTarget = playerTransform;
                    return asteroid;
                case  EnemyType.Commet:
                    var commet = Object.Instantiate(Resources.Load<Commet>("Enemy/Commet"));
                    commet.MoveTarget = playerTransform;
                    return commet;
                case EnemyType.SpaceDebris:
                    var spaceDebris = Object.Instantiate(Resources.Load<SpaceDebris>("Enemy/SpaceDebris"));
                    spaceDebris.MoveTarget = playerTransform;
                    return spaceDebris;
                default:
                    throw new NotSupportedException();
                    
            }
        }
    }
}