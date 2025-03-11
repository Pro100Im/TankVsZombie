using DG.Tweening;
using UnityEngine;

namespace Game.Tank
{
    public class TankMovement : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 5;
        [SerializeField] private float accelerationTime = 10f;
        [SerializeField] private float decelerationTime = 1f;
        [SerializeField] private float rotationSpeed = 40f;
        [Space]
        [SerializeField] private Rigidbody2D rb;

        private float currentSpeed = 0f;
        private float currentRotation = 0f;

        private Tweener speedTweener;

        public void Move(float value)
        {
            float targetSpeed = value * maxSpeed;
            if(speedTweener != null && speedTweener.IsActive()) speedTweener.Kill();

            if(value != 0)
                speedTweener = DOTween.To(() => currentSpeed, x => currentSpeed = x, targetSpeed, accelerationTime).SetEase(Ease.OutQuad);
            else
                speedTweener = DOTween.To(() => currentSpeed, x => currentSpeed = x, 0, decelerationTime).SetEase(Ease.InQuad);
        }

        public void Rotation(float value)
        {
            currentRotation = value * rotationSpeed;
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = transform.up * currentSpeed;

            Debug.Log($"rb {rb.linearVelocityY}");

            if(currentRotation != 0)
                rb.rotation -= currentRotation * Time.fixedDeltaTime;
        }
    }
}