using UnityEngine;

namespace Asteroids
{
    public interface IEnemyMover
    {
        public void Move(Vector3 moveTarget);
    }
}