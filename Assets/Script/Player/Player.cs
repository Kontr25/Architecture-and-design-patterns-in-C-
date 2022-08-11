using UnityEngine;
namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private float _acceleration;
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;

        private Ship _ship;
        private Camera _camera;
        private Shooting _shooting;
        private Health _health;

        private void Start()
        {
            _camera = Camera.main;
            _shooting = new Shooting(_bullet, _barrel, _force);

            var moveTransform = new AccelerationMove(_playerRigidbody, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var health = new Health(_hp);
            _ship = new Ship(moveTransform, rotation, health);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }



            if (Input.GetButtonDown("Fire1")) _shooting.Shot();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _health.OnDamaged();
        }
    }
}
