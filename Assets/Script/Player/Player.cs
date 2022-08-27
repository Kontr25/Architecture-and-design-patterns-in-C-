using Script.Bullets;
using Script.UI;
using UnityEngine;
namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private float _acceleration;
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _barrel;

        private Ship _ship;
        private Camera _camera;
        private Shooting _shooting;
        public Health  PlayerHealth {get; set;}

        private void Start()
        {
            var healthBar = Object.Instantiate(Resources.Load<HealthBar>("UIBars/HealthBar"));
            healthBar.SetFollowTarget(transform);
            _camera = Camera.main;

            var moveTransform = new AccelerationMove(_playerRigidbody, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            PlayerHealth = new Health(_hp, healthBar);
            _ship = new Ship(moveTransform, rotation, PlayerHealth);
            _shooting = new Shooting(_bullet, _barrel);
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
    }
}
