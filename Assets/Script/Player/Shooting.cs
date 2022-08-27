using System;
using UnityEngine;
using Asteroids.Object_Pool;
using Script.Bullets;
using Script.ServiceLocator;

namespace Asteroids
{
    internal sealed class Shooting : MonoBehaviour
    {
        
        
        private readonly Bullet _bullet;
        private readonly Transform _barrel;
        private int _pollCapacity = 5;
        private ObjectPool<Bullet> _pool;
        private IServiceLocator<IService<Bullet>> _locator;


        public Shooting(Bullet bullet, Transform barrel)
        {
            _bullet = bullet;
            _barrel = barrel;

            _pool = new ObjectPool<Bullet>(_bullet, _pollCapacity, _barrel)
            {
                AutoExpand = true
            };
            
            
            _locator = new ServiceLocator<IService<Bullet>>();
            var bulletPoolService = new BulletPoolService(_pool);
            _locator.Register(bulletPoolService);
        }

        public void Shot()
        {
            CreateBullet();
        }

        private void CreateBullet()
        {
            var BulletPool = _locator.GetTP<BulletPoolService>();
            var bullet = BulletPool._bulletPool.GetFreeElement();
            bullet.transform.position = _barrel.position;
        }
    }
}
