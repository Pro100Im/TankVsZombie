using UnityEngine;

namespace Game.Bullet
{
    public sealed class MiniGunBullet : BaseBullet
    {
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Hit");
        }
    }
}