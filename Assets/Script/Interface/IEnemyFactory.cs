using Script.Enemy;
using UnityEngine;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy Create(EnemyHealth hp);
    }
}

