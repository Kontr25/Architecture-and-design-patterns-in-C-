using Asteroids;

namespace Script.Enemy
{
    public class EnemyDamager: IEnemyDamager
    {
        private float _damageAmount;

        public EnemyDamager(float DamageAmount)
        {
            _damageAmount = DamageAmount;
        }
        
        public void OnDamage(Health HealthForDamage)
        {
            HealthForDamage.OnDamaged(_damageAmount);
        }
    }
}