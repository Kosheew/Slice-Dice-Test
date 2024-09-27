using UnityEngine;
using UnityEngine.UI;

namespace Game.MVP
{
    public abstract class View : MonoBehaviour
    {
        protected Presenter _presenter;

        [SerializeField] private Text _helthText;
        [SerializeField] private Text _defenceText;

        public virtual void Init(Presenter precenter)
        {
            _presenter = precenter;
        }

        public void UpdateHealth(int value)
        {
            _helthText.text = $"{value}";
        }

        public void UpdateDefence(int value)
        {
            _defenceText.text = $"{value}";
        }
    }
}