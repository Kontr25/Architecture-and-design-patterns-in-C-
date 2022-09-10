using System;
using Asteroids;
using UnityEngine;

namespace Script.Lesson_8
{
    public class ChainOfResponsibility : MonoBehaviour
    {
        private bool _isCanModifire = true;
        
        private void ChainOfResponsibilityExample2(Player player)
        {
            var root = new HealthModifire(player);
            root.Add(new IncreaseHealthModifire(player, 20));
            root.Add(new IncreaseHealthModifire(player, 40));
            root.Handle();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player player))
            {
                if (_isCanModifire)
                {
                    Debug.Log("HealthModifireComplete");
                    ChainOfResponsibilityExample2(player);
                    Destroy(gameObject, 2f);
                }
            }
        }
    }
}
