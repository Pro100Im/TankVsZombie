using DG.Tweening;
using UnityEngine;

namespace Game.Tank
{
    public class TankTurret : MonoBehaviour
    {
        [SerializeField] private MiniGun miniGun;
        [SerializeField] private float rotationSpeed = 25f;

        private const int Multiply = 100;

        private Camera _camera;

        private Vector3 _target;

        private void Start() => _camera = Camera.main;

        public void SetTarget(Vector2 target)
        {
            _target = _camera.ScreenToWorldPoint(target);
        }

        public void Fire()
        {
            miniGun.Shoot();
        }

        private void Update() => Aiming();

        private void Aiming()
        {
            var targetRotation = Quaternion.LookRotation(_target - transform.position, transform.TransformDirection(Vector3.back));

            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                new Quaternion(0, 0, targetRotation.z, targetRotation.w),
                rotationSpeed * Time.deltaTime * Multiply);
        }
    }
}