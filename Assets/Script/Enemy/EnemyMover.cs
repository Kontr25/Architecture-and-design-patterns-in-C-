using UnityEngine;

namespace Asteroids
{
    public class EnemyMover: IEnemyMover
    {
        private readonly Rigidbody2D _enemyRigidbody;
        private readonly float _speed;
        
        public EnemyMover(Rigidbody2D enemyRigidbody, float speed)
        {
            _enemyRigidbody = enemyRigidbody;
            _speed = speed;
        }
        
        public void Move(Vector3 target)
        {
            Vector3 direction = target - _enemyRigidbody.transform.position;
            _enemyRigidbody.velocity = direction * _speed * Time.deltaTime;
        }
    }
}