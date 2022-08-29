using UnityEngine;

namespace Asteroids
{
    public interface IWeapon
    {
        public void Shot();
        public void SetShotSound(AudioSource shotSound);

        public void SetBarrelPosition(Transform barrelPosition);
    }
}