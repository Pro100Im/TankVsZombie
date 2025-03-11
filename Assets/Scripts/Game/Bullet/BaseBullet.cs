using System.Collections;
using UnityEngine;

namespace Game.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [Space]
        [SerializeField] private float speedForce = 5f;
        [SerializeField] private float lifeTime = 3f;

        private BulletPool _bulletPool;
        private Coroutine _coroutine;

        public void Init(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public void AddForce()
        {
            rb.AddForce(transform.up * speedForce, ForceMode2D.Impulse);

            _coroutine = StartCoroutine(LifeTime());
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);

            _bulletPool.Despawn(this);
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if(_coroutine != null)
                StopCoroutine(_coroutine);

            _bulletPool.Despawn(this);
        }
    }
}