using UnityEngine;

namespace Game.Bullet
{
    public sealed class MiniGunBullet : BaseBullet
    {
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);

            collision.gameObject.TryGetComponent(out IDamageable damageable);

            if(damageable != null)
                damageable.TakeDamage(damage);
        }
    }
}