using Asteroids;
using UnityEngine;
using DG.Tweening;

namespace Script.Modification
{
    public abstract class ModificationWeapon: MonoBehaviour, IWeapon
    {
        private Weapon _weapon;
        protected Transform _mufflerTransform;
        private protected bool _isMufflerModifire = false;
        private protected bool _isAimModifire = false;
        public abstract Weapon AddModification(Weapon weapon, ModificationType modificationType);
        public abstract Weapon RemoveModification(Weapon weapon, ModificationType modificationType);
        
        public void ApplyModification(Weapon weapon, ModificationType modificationType)
        {
            _weapon = AddModification(weapon, modificationType);
        }
        
        public void DisableModification(Weapon weapon, ModificationType modificationType)
        {
            _weapon = RemoveModification(weapon, modificationType);
        }

        public void Shot()
        {
            if(_isMufflerModifire) MufflerPanshScale();
            _weapon.Shot();
        }

        public void MufflerPanshScale()
        {
            _mufflerTransform.transform.DOScaleY(0.6f, 0.2f).onComplete = () =>
            {
                _mufflerTransform.transform.DOScaleY(1f, 0.5f);
            };
        }

        public void SetShotSound(AudioSource shotSound)
        {
            throw new System.NotImplementedException();
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}