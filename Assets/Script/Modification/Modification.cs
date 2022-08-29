using System;
using Asteroids;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.Modification
{
    public class Modification : ModificationWeapon
    {
        private readonly IMuffler _muffler;
        private readonly Transform _mufflerParent;
        private readonly IAim _aim;
        private Transform _aimParent;

        private GameObject _mufflerObject;
        private GameObject _aimObject;

    public Modification(AudioSource mufflerShotSound, IMuffler muffler,
        Transform mufflerParent)
        {
            _muffler = muffler;
            _mufflerParent = mufflerParent;
        }
    
    public Modification(IAim aim,
        Transform aimParent)
    {
        _aim = aim;
        _aimParent = aimParent;
    }

        public override Weapon AddModification(Weapon weapon, ModificationType modificationType)
        {
            switch (modificationType)
            {
                case ModificationType.Muffler:
                    _isMufflerModifire = true;
                    var muffler = Object.Instantiate(_muffler.MufflerInstance,
                        _mufflerParent.position, _mufflerParent.rotation,_mufflerParent);
                    _mufflerObject = muffler;
                    _mufflerTransform = muffler.transform;
                    weapon.SetShotSound(_muffler.AudioSourceMuffler);
                    weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
                    break;
                case ModificationType.Aim:
                    _isAimModifire = true;
                    var aim = Object.Instantiate(_aim.AimInstance,
                        _aimParent.position, _aimParent.rotation,_aimParent);
                    _aimObject = aim;
                    break;
                case ModificationType.Engine:
                    throw new Exception("This modification does not exist yet");
            }
            return weapon;
        }

        public override Weapon RemoveModification(Weapon weapon, ModificationType modificationType)
        {
            switch (modificationType)
            {
                case ModificationType.Aim:
                    _isAimModifire = false;
                    _aimObject.SetActive(false);
                    break;
                case ModificationType.Muffler:
                    _isMufflerModifire = false;
                    weapon.SetShotSound(null);
                    _mufflerObject.SetActive(false);
                    break;
            }

            return weapon;
        }
    }
}