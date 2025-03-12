using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public sealed class Pause : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 0.3f;
        [Space]
        [SerializeField] private GameObject panel;

        private bool _isPaused = false;

        private TankInput _input;

        public void Init(TankInput input)
        {
            _input = input;

            _input.ActionMap.Pause.canceled += PauseGame;
        }

        private void PauseGame(InputAction.CallbackContext context)
        {
            if(!_isPaused)
            {
                Time.timeScale = 0;

                panel.SetActive(true);

                _isPaused = true;
            }
            else
            {
                Time.timeScale = 1;

                panel.SetActive(false);

                _isPaused = false;
            }
        }

        private void OnDestroy() => _input.ActionMap.Pause.canceled -= PauseGame;
    }
}