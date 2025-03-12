using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Game
{
    public sealed class Pause : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 0.3f;
        [Space]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button backToMenuBtb;

        private bool _isPaused = false;

        private TankInput _input;

        private void Awake() => backToMenuBtb.onClick.AddListener(BackToMenu);

        public void Init(TankInput input)
        {
            _input = input;

            _input.ActionMap.Pause.canceled += PauseGame;
        }

        private void PauseGame(InputAction.CallbackContext context)
        {
            if(!_isPaused)
            {
                //Time.timeScale = 0;

                _canvasGroup.gameObject.SetActive(true);

                _isPaused = true;
            }
            else
            {
                //Time.timeScale = 1;

                _canvasGroup.gameObject.SetActive(false);

                _isPaused = false;
            }
        }

        //private void FadePanel(float endValue)
        //{
        //    _canvasGroup.DOFade(endValue, fadeDuration).SetUpdate(false);
        //    _canvasGroup.blocksRaycasts = endValue > 0;
        //}

        private void BackToMenu()
        {
            Debug.Log("Button Clicked!");

            //Time.timeScale = 1;

            SceneLoader.Instance.LoadMenuScene();
        }

        private void OnDestroy()
        {
            _input.ActionMap.Pause.canceled -= PauseGame;

            backToMenuBtb.onClick.RemoveListener(BackToMenu);
        }
    }
}