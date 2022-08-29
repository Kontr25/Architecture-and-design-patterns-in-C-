using UnityEngine;

namespace Asteroids
{
    public interface IAim
    {
        GameObject AimInstance { get; }
        Transform BarrelPositionMuffler { get; }
    }
}