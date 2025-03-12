using UnityEngine;

namespace Game.Bullet
{
    public class BigGunBullet : BaseBullet
    {
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Big Hit");
        }
    }
}