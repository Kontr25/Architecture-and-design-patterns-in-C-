using UnityEngine;

namespace Asteroids
{
    public interface IHealth
    {
        float Hp { get; }

        void OnDamaged();
    }
}
