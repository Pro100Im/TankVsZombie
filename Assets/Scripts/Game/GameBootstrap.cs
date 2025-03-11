using Assets.Scripts.Game.UI;
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

            var turretModeObservable = FindFirstObjectByType(typeof(TankTurret)) as ITurretModeObservable;
            var turretModeObserver = FindFirstObjectByType(typeof(TurretModeIndicator)) as ITurretModeObserver;

            turretModeObservable.AddTurretModeObserver(turretModeObserver);

            SceneLoader.Instance.FadeScreen(0);
        }
    }
}