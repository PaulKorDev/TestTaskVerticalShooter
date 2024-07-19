using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class PlayerGUI : MonoBehaviour
    {
        [SerializeField] private Text _hpValueText;

        private void Start()
        {
            ServiceLocator.Get<EventBus>().OnHealthChanged.Subscribe(DisplayHP);

        }

        private void DisplayHP(int newHP)
        {
            _hpValueText.text = newHP.ToString();
        }
    }
}
