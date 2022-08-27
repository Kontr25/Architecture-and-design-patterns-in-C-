using Script.Bullets;
using UnityEngine;

namespace Script.BulletBuilder
{
    public class BulletBuilder: MonoBehaviour
    {
        protected GameObject _gameObject;

        public BulletBuilder()
        {
            _gameObject = new GameObject();
        }

        protected BulletBuilder(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public BulletBuilder Sprite(Sprite sprite)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return this;
        }

        public BulletBuilder ShotComponent( float shotforce)
        {
            var component = GetOrAddComponent<LaserBullet>();
            component.ShotForce = shotforce;
            var bulletrigidbody = GetOrAddComponent<Rigidbody2D>();
            var b = (bulletrigidbody.constraints & RigidbodyConstraints2D.FreezeRotation) != 0;
            b = true;
            bulletrigidbody.mass = 1f;
            component.BulletRigidbody = bulletrigidbody;
            return this;
        }

        public BulletBuilder BoxColliedr2D()
        {
            var component = GetOrAddComponent<BoxCollider2D>();
            component.isTrigger = true;
            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }
        
        
    }
}