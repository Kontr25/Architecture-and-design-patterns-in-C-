using UnityEngine;
using Asteroids.Object_Pool;
using Script.Bullets;

namespace Asteroids
{
    internal sealed class Shooting : MonoBehaviour
    {
        
        
        private readonly Bullet _bullet;
        private readonly Transform _barrel;
        private int _pollCapacity = 5;
        private ObjectPool<Bullet> _pool;


        public Shooting(Bullet bullet, Transform barrel)
        {
            _bullet = bullet;
            _barrel = barrel;

            _pool = new ObjectPool<Bullet>(_bullet, _pollCapacity, _barrel)
            {
                AutoExpand = true
            };
        }

        public void Shot()
        {
            CreateBullet();
        }

        private void CreateBullet()
        {
            var bullet = _pool.GetFreeElement();
            bullet.transform.position = _barrel.position;
        }
    }
}
