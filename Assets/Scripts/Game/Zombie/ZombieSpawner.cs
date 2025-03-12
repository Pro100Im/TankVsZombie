using System.Collections;
using UnityEngine;

namespace Game.Zombie
{
    public sealed class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private float maxSpawnRadius = 20f;
        [SerializeField] private float minSpawnRadius = 10f;
        [SerializeField] private float pointRadius = 2f; 
        [SerializeField] private float smallZombieProbability = .75f;
        [SerializeField] private float maxSpawnDelay = 5f;
        [SerializeField] private float minSpawnDelay = 2f;
        [Space]
        [SerializeField] private int spawnAttempts = 10;
        [Space]
        [SerializeField] private ZombieController smallZombiePrefab;
        [SerializeField] private ZombieController bigZombiePrefab;
        [SerializeField] private LayerMask obstacleLayer;

        private Transform _target;

        public void Init(Transform target)
        {
            _target = target;

            StartCoroutine(SpawnZombiesPeriodically());
        }

        private IEnumerator SpawnZombiesPeriodically()
        {
            while(true)
            {
                float delay = Random.Range(minSpawnDelay, maxSpawnDelay);

                yield return new WaitForSeconds(delay);

                SpawnZombie();
            }
        }

        private void SpawnZombie()
        {
            if(_target == null) 
                return;

            for(int i = 0; i < spawnAttempts; i++)
            {
                var randomDistance = Random.Range(minSpawnRadius, maxSpawnRadius);
               
                var randomPoint = _target.position + Vector3.one * randomDistance;
                randomPoint.z = 0;

                if(!Physics2D.OverlapCircle(randomPoint, pointRadius, obstacleLayer))
                {
                    var zombiePrefab = Random.value < smallZombieProbability ? smallZombiePrefab : bigZombiePrefab;
                    var zombie = Instantiate(zombiePrefab, randomPoint, Quaternion.identity);
                    zombie.SetTarget(_target);

                    return;
                }
            }
        }
    }
}