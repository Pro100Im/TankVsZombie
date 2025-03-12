using Game.Tank;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.UI
{
    public sealed class TurretModeIndicator : MonoBehaviour, ITurretModeObserver
    {
        [SerializeField] Toggle toggleMiniGun;
        [SerializeField] Toggle toggleBigGun;

        public void OnTurretModeChanged(BaseGun currentGun)
        {
            if(currentGun is BigGun)
                toggleBigGun.isOn = true;
            else
                toggleMiniGun.isOn = true;
        }
    }
}