using Game.Bullet;
using UnityEngine;

namespace Game.Tank
{
    public abstract class BaseGun : MonoBehaviour
    {
        [SerializeField] protected Transform firePoint;
        [SerializeField] protected BulletPool bulletPool;

        public virtual void Shoot()
        {
            var bullet = bulletPool.Spawn(firePoint.position, firePoint.rotation);
            bullet.AddForce();
        }
    }
}