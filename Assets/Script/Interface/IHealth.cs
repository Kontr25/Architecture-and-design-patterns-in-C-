using UnityEngine;

namespace Asteroids
{
    public interface IHealth
    {
        float remainingHealth { get; }

        void OnDamaged(float remainingHealth);
    }
}
