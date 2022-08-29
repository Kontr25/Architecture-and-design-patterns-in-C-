using System;
using Asteroids;
using UnityEngine;
using DG.Tweening;

namespace Script.Modification
{
    public class ModificationObject: MonoBehaviour
    {
        [SerializeField] private ModificationType _modificationType;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player player))
            {
                switch (_modificationType)
                {
                    case ModificationType.Muffler:
                        player.ModificateWeaponWithMuffler();
                        break;
                    case ModificationType.Engine:
                        break;
                    case ModificationType.Aim:
                        player.ModificateWeaponWithAim();
                        break;
                }

                transform.DOScale(0.01f, 0.3f).onComplete = () =>
                {
                    Destroy(gameObject);
                };
            }
        }
    }
}