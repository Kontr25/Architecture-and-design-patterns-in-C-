using Asteroids;
using UnityEngine;

namespace Script.Modification
{
    public class Aim: IAim
    {
        public GameObject AimInstance { get; }
        public Transform BarrelPositionMuffler { get; }

        public Aim(GameObject aimObject, Transform barrel)
        {
            AimInstance = aimObject;
            BarrelPositionMuffler = barrel;
        }
    }
}