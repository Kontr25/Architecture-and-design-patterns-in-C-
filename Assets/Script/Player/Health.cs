using System;
using UnityEngine;

namespace Asteroids
{
    internal class Health : MonoBehaviour, IHealth
    {
        public float Hp { get; protected set; }

        public Health(float hp)
        {
            Hp = hp;
        }

        public void OnDamaged()
        {
            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Hp--;
            }
        }
    }
}
