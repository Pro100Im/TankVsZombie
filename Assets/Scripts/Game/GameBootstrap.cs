using Game.Tank;
using UnityEngine;

namespace Game
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private TankSpawner tankSpawner;

        private void Start()
        {
            var tank = tankSpawner.Spawn();
            tank.Init();

            SceneLoader.Instance.FadeScreen(0);
        }
    }
}