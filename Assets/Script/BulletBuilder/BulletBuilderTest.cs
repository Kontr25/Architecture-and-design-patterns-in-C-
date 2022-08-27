using System;
using UnityEngine;

namespace Script.BulletBuilder
{
    public class BulletBuilderTest: MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;

        private void Start()
        {
            var BulletBuilder = new BulletBuilder();
            var buildresult = BulletBuilder
                .Sprite(_sprite)
                .ShotComponent(5000)
                .BoxColliedr2D();
        }
    }
}