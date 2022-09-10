using Asteroids;
using UnityEngine;

namespace Script.Lesson_8
{
    public class IncreaseHealthModifire : HealthModifire
    {
        private readonly float _hpCount;


        public IncreaseHealthModifire(Player player, float hpCount) : base(player)
        {
            _hpCount = hpCount;
        }

        public override void Handle()
        {
            _player.PlayerHealth.HealthUp(_hpCount);

            base.Handle();
        }
    }
}