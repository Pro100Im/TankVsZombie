using Game.Tank;
using Game.Zombie;
using Unity.Cinemachine;
using UnityEngine;

namespace Game
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        private void Start()
        {
            var tankSpawner = FindFirstObjectByType(typeof(TankSpawner)) as TankSpawner;
            var tank = tankSpawner.Spawn();
            tank.Init();

            var tankHpBar = FindFirstObjectByType(typeof(TankHpBar)) as TankHpBar;
            tankHpBar.Init(tank.CurrentHp);

            tank.OnHpChanged += tankHpBar.ChangeHp;

            var cinamachine = FindFirstObjectByType(typeof(CinemachineCamera)) as CinemachineCamera;
            cinamachine.Follow = tank.transform;

            var turretModeObservable = FindFirstObjectByType(typeof(TankTurret)) as ITurretModeObservable;
            var turretModeObserver = FindFirstObjectByType(typeof(TurretModeIndicator)) as ITurretModeObserver;
            turretModeObservable.AddTurretModeObserver(turretModeObserver);

            var killCounter = FindFirstObjectByType(typeof(KillCounter)) as KillCounter;

            var zombieSpawner = FindFirstObjectByType(typeof(ZombieSpawner)) as ZombieSpawner;
            zombieSpawner.Init(tank.transform, killCounter);

            SceneLoader.Instance.FadeScreen(0);
        }
    }
}