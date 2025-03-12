using System;
using UnityEngine;

namespace Game.Zombie
{
    public sealed class ZombieController : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHp = 100;
        [Space]
        [SerializeField] private ZombieMovement zombieMovement;
        [SerializeField] private ZombieAttack zombieAttack;
        [SerializeField] private ZombieHpBar zombieHpBar;

        public int CurrentHp { get; private set; }

        private Transform _target;

        private void Awake()
        {
            CurrentHp = maxHp;

            zombieHpBar.Init(CurrentHp);
        }

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
            CurrentHp -= damage;
            CurrentHp = Math.Clamp(CurrentHp, 0, maxHp);

            zombieHpBar.ChangeHp(CurrentHp);
        }
    }
}