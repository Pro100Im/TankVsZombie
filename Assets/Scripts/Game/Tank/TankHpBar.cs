using UnityEngine;
using UnityEngine.UI;

namespace Game.Tank
{
    public class TankHpBar : MonoBehaviour
    {
        [SerializeField] private Slider hp;

        private int _maxHp;

        public void Init(int maxHp)
        {
            _maxHp = maxHp;
        }

        public void ChangeHp(int currentHp)
        {

        }
    }
}