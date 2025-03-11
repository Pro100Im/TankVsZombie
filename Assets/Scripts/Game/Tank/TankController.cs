using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Tank
{
    public class TankController : MonoBehaviour
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
        }

        public void Init() => input.ActionMap.Enable();

        public void MoveInput(InputAction.CallbackContext context)
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

        private void OnDestroy()
        {
            input.ActionMap.Move.performed -= MoveInput;
            input.ActionMap.Move.canceled -= MoveInput;

            input.ActionMap.Point.performed -= AimInput;
            input.ActionMap.Fire.performed -= FireInput;

            input.ActionMap.Disable();
        }
    }
}