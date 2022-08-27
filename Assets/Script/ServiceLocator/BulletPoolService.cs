using Asteroids.Object_Pool;
using Script.Bullets;

namespace Script.ServiceLocator
{
    public class BulletPoolService: PoolServiceBase<Bullet>
    {
        public BulletPoolService(ObjectPool<Bullet> bulletPool) : base(bulletPool)
        {
        }
    }
}