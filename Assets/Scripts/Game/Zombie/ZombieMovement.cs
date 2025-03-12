using UnityEngine;

namespace Game.Zombie
{
    public class ZombieMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float rotationSpeed = 5f;
        [Space]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private LayerMask obstacleLayer;

        private const int Multiply = 100;

        private Transform _target;

        public void SetTarget(Transform target) => _target = target;

        private void FixedUpdate()
        {
            if(_target == null) 
                return;

            Vector2 direction = (_target.position - transform.position).normalized;
            var hit = Physics2D.Raycast(transform.position, direction, 2, obstacleLayer);

            if(hit.collider != null)
            {
                Vector2 avoidanceDirection = Vector2.Perpendicular(hit.normal) * 1;
                direction += avoidanceDirection;
            }

            var targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var angle = Mathf.LerpAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);

            rb.MoveRotation(angle);
            rb.AddForce(direction * moveSpeed * Multiply, ForceMode2D.Force);

            rb.linearVelocityY = Mathf.Clamp(rb.linearVelocity.y, -moveSpeed, moveSpeed);
        }
    }
}