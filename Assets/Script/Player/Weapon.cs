using System;
using UnityEngine;
using Asteroids.Object_Pool;
using Script.Bullets;
using Script.ServiceLocator;

namespace Asteroids
{
    public sealed class Weapon : MonoBehaviour, IWeapon
    {
        
        
        private readonly Bullet _bullet;
        private Transform _barrel;
        private int _pollCapacity = 5;
        private ObjectPool<Bullet> _pool;
        private IServiceLocator<IService<Bullet>> _locator;
        private AudioSource _defaultShotSound;
        private AudioSource _shotSound;


        public Weapon(Bullet bullet, Transform barrel, AudioSource defaultShotSound)
        {
            _defaultShotSound = defaultShotSound;
            _shotSound = _defaultShotSound;
            _bullet = bullet;
            SetBarrelPosition(barrel);

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
            _shotSound.Play();
        }

        public void SetShotSound(AudioSource shotSound)
        {
            if (shotSound != null) _shotSound = shotSound;
            else _shotSound = _defaultShotSound;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            _barrel = barrelPosition;
        }

        private void CreateBullet()
        {
            var BulletPool = _locator.GetTP<BulletPoolService>();
            var bullet = BulletPool._bulletPool.GetFreeElement();
            bullet.transform.position = _barrel.position;
        }
    }
}
