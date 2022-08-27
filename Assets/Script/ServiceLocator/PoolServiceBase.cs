using System;
using System.Collections.Generic;
using Asteroids.Object_Pool;
using Script.Bullets;
using UnityEngine;

namespace Script.ServiceLocator
{
    public abstract class PoolServiceBase <T>: IService<Bullet>
    {
        public ObjectPool<Bullet> _bulletPool { get; }
        
        public PoolServiceBase(ObjectPool<Bullet> bulletPool )
        {
            _bulletPool = bulletPool;
        }

        
    }
}