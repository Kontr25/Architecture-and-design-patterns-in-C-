using UnityEngine;
namespace Asteroids
{
    internal sealed class Shooting : MonoBehaviour
    {
        private readonly Rigidbody2D _bullet;
        private readonly Transform _barrel;
        private readonly float _force;

        public Shooting(Rigidbody2D bullet, Transform barrel, float force)
        {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
        }

        public void Shot()
        {
            var temAmmunition = Instantiate(_bullet, _barrel.position,  _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
        }
    }
}
