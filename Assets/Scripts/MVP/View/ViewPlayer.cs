using UnityEngine;
using UnityEngine.UI;

namespace Game.MVP
{
    public class ViewPlayer : View
    {
        [SerializeField] private Text _countRerolText;

        [SerializeField] private Button _buttonRerol;

        [SerializeField] private Button _buttonAttack;

        public override void Init(Presenter presenter)
        {
            _presenter = presenter;

            _buttonRerol.onClick.AddListener(() => {
                _presenter.ShakeDice();
            });

            _buttonAttack.onClick.AddListener(() =>
            {
                _presenter.SetAttack();
            });
        }

        public void UpdateCountRerol(int value)
        {
            _countRerolText.text = $"Count: {value}";
        }
    }
}
