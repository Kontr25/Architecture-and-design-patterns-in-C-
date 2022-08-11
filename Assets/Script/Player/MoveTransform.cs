using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform: IMove
    {
        private readonly Rigidbody2D _playerRigidBody;
        public float Speed { get; protected set; }
        private Vector3 _move;

        public MoveTransform(Rigidbody2D playerRigidbody, float speed)
        {
            _playerRigidBody = playerRigidbody;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical)
        {
            _playerRigidBody.velocity = new Vector2(horizontal * Speed, vertical * Speed);
        }
    }
}
