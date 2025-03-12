using UnityEngine;

namespace Game.Bullet
{
    public sealed class BigGunBullet : BaseBullet
    {
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
            Debug.Log("Big Hit");
        }
    }
}