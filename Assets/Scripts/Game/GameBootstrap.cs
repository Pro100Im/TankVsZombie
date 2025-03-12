using Assets.Scripts.Game.UI;
using Game.Tank;
using Game.Zombie;
using Unity.Cinemachine;
using UnityEngine;

namespace Game
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private TankSpawner tankSpawner;
        [SerializeField] private ZombieSpawner zombieSpawner;

        private void Start()
        {
            var tank = tankSpawner.Spawn();
            tank.Init();

            var cinamachine = FindFirstObjectByType(typeof(CinemachineCamera)) as CinemachineCamera;
            cinamachine.Follow = tank.transform;

            var turretModeObservable = FindFirstObjectByType(typeof(TankTurret)) as ITurretModeObservable;
            var turretModeObserver = FindFirstObjectByType(typeof(TurretModeIndicator)) as ITurretModeObserver;

            turretModeObservable.AddTurretModeObserver(turretModeObserver);

            zombieSpawner.Init(tank.transform);

            SceneLoader.Instance.FadeScreen(0);
        }
    }
}