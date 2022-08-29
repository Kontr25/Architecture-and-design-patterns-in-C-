using System;
using Asteroids;
using UnityEngine;

namespace Script.Modification
{
    public class TestModificatorRemover: MonoBehaviour
    {
        [SerializeField] private ModificationType _typeForRemove;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player player))
            {
                player.RemoveModification(_typeForRemove);
            }
        }
    }
}