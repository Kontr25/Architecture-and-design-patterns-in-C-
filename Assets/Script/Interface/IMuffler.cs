using UnityEngine;

namespace Asteroids
{
    public interface IMuffler
    {
        AudioSource AudioSourceMuffler { get; }
        Transform BarrelPositionMuffler { get; }
        GameObject MufflerInstance { get; }
    }
}