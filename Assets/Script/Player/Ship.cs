using UnityEngine;
namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation, IHealth
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IHealth _healthImplementation;
        public float Speed => _moveImplementation.Speed;
        public float remainingHealth => _healthImplementation.remainingHealth;

        public Ship(IMove moveImplementation, IRotation rotationImplementation, IHealth healthImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _healthImplementation = healthImplementation;
        }
        public void Move(float horizontal, float vertical)
        {
            _moveImplementation.Move(horizontal, vertical);
        }
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }
        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void OnDamaged(float remainingHealth)
        {
            _healthImplementation.OnDamaged(remainingHealth);
        }
    }
}

