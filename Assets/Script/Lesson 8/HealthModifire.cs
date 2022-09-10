using Asteroids;
using UnityEngine;

namespace Script.Lesson_8
{
    public class HealthModifire : MonoBehaviour
    {
        protected Player _player;
        protected HealthModifire Next;

        public HealthModifire(Player player)
        {
            _player = player;
        }

        public void Add(HealthModifire heHealthModifire)
        {
            if (Next != null)
            {
                Next.Add(heHealthModifire);
            }
            else
            {
                Next = heHealthModifire;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}