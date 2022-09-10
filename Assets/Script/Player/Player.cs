using Script.Bullets;
using Script.Modification;
using Script.UI;
using UnityEngine;
namespace Asteroids
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private float _acceleration;
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private GameObject _mufflerObj;
        [SerializeField] private GameObject _aimObj;
        [SerializeField] private AudioSource _mufflerShotSound;
        [SerializeField] private AudioSource _defaultShotSound;

        private Ship _ship;
        private Camera _camera;
        private Weapon _weapon;
        private IWeapon _iweapon;
        private ModificationWeapon _modificationWeaponAim;
        private ModificationWeapon _modificationWeaponMuffler;
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
            _weapon = new Weapon(_bullet, _barrel,_defaultShotSound);
            _iweapon = _weapon;

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



            if (Input.GetButtonDown("Fire1")) _iweapon.Shot();
        }

        public void ModificateWeaponWithMuffler()
        {
            var muffler = new Muffler(_mufflerShotSound, _barrel, _mufflerObj);

            _modificationWeaponMuffler = new Modification(_mufflerShotSound, muffler, _barrel);
            
            _modificationWeaponMuffler.ApplyModification(_weapon, ModificationType.Muffler);

            _iweapon = _modificationWeaponMuffler;
        }

        public void ModificateWeaponWithAim()
        {
            var aim = new Aim(_aimObj, _barrel);

            _modificationWeaponAim = new Modification(aim, _barrel);
            
            _modificationWeaponAim.ApplyModification(_weapon, ModificationType.Aim);
        }

        public void RemoveModification(ModificationType modificationType)
        {
            switch (modificationType)
            {
                case ModificationType.Aim:
                    _modificationWeaponAim.DisableModification(_weapon, ModificationType.Aim);
                    break;
                case ModificationType.Muffler:
                    _modificationWeaponMuffler.DisableModification(_weapon, ModificationType.Muffler);
                    break;
            }
        }
    }
}
