using UnityEngine;

namespace Game.Zombie
{
    public sealed class ZombieController : MonoBehaviour, IDamageable
    {
        [SerializeField] private ZombieMovement zombieMovement;
        [SerializeField] private ZombieAttack zombieAttack;
        [Space]
        [SerializeField] private LayerMask layer;

        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;

            zombieMovement.SetTarget(target);
            zombieAttack.SetTarget(target);
        }

        private void FixedUpdate()
        {
            var distance = Vector3.Distance(transform.position, _target.position);

            zombieAttack.Attack(distance);
        }

        public void TakeDamage(int damage)
        {
            
        }
    }
}