using DG.Tweening;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneAsset menuScene;
    [SerializeField] private SceneAsset gameScene;
    [Space]
    [SerializeField] private Image transitionScreen;
    [SerializeField] private float fadeDuration = .3f;

    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMenuScene() => FadeScreen(1, () => LoadScene(menuScene.name));

    public void LoadGameScene() => FadeScreen(1, () => LoadScene(gameScene.name));

    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

    public void FadeScreen(float endValue, Action callback = null)
    {
        DOTween.Kill(transitionScreen);

        transitionScreen.raycastTarget = endValue > 0;
        transitionScreen.DOFade(endValue, fadeDuration)
            .OnComplete(() => callback?.Invoke());
    }
}
