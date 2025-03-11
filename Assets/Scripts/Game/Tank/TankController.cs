using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Tank
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private TankMovement movement;

        private TankInput input;

        private void Awake()
        {
            input = new TankInput();

            input.ActionMap.Move.performed += OnInput;
            input.ActionMap.Move.canceled += OnInput;

            input.ActionMap.Enable();
        }

        public void OnInput(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();

            movement.Move(input.y);
            movement.Rotation(input.x);
        }

        private void OnDestroy()
        {
            input.ActionMap.Move.performed -= OnInput;
            input.ActionMap.Move.canceled -= OnInput;

            input.ActionMap.Disable();
        }
    }
}