using UnityEngine;

namespace Game
{
    public class GameBootstrap : MonoBehaviour
    {
        private void Start()
        {
            SceneLoader.Instance.FadeScreen(0);
        }
    }
}