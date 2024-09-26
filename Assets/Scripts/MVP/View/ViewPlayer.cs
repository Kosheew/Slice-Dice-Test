using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.MVP;

namespace Game.MVP.Player
{
    public class ViewPlayer : View
    {

        [SerializeField] private Button _buttonRerol;

        [SerializeField] private Button _buttonAttack;

        public override void Init(Presenter presenter)
        {
            _precenter = presenter;

            _buttonRerol.onClick.AddListener(() => {
                _precenter.ShakeDice();
            });

            _buttonAttack.onClick.AddListener(() =>
            {
                _precenter.SetAttack();
            });


        }
    }
}
