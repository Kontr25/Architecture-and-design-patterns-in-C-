using Asteroids.Object_Pool;
using Script.Bullets;
using UnityEngine;

namespace Script.ServiceLocator
{
    public interface IService<T> where T: MonoBehaviour
    {
        public ObjectPool<Bullet> _bulletPool { get; }
    }
}