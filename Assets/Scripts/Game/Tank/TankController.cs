using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Tank
{
    public sealed class TankController : MonoBehaviour, IDamageable
    {
        [SerializeField] private TankMovement movement;
        [SerializeField] private TankTurret turret;

        private TankInput input;

        private void Awake()
        {
            input = new TankInput();

            input.ActionMap.Move.performed += MoveInput;
            input.ActionMap.Move.canceled += MoveInput;

            input.ActionMap.Point.performed += AimInput;
            input.ActionMap.Fire.performed += FireInput;

            input.ActionMap.SwapGun.started += SwapTurret;
        }

        public void Init() => input.ActionMap.Enable();

        private void MoveInput(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>().normalized;

            movement.Move(input.y);
            movement.Rotation(input.x);
        }

        private void AimInput(InputAction.CallbackContext context)
        {
            var target = context.ReadValue<Vector2>();

            turret.SetTarget(target);
        }

        private void FireInput(InputAction.CallbackContext context) => turret.Fire();

        private void SwapTurret(InputAction.CallbackContext context) => turret.SwapTurretMode();

        public void TakeDamage(int damage)
        {
            
        }

        private void OnDestroy()
        {
            input.ActionMap.Move.performed -= MoveInput;
            input.ActionMap.Move.canceled -= MoveInput;

            input.ActionMap.Point.performed -= AimInput;
            input.ActionMap.Fire.performed -= FireInput;

            input.ActionMap.SwapGun.started -= SwapTurret;

            input.ActionMap.Disable();
        }
    }
}