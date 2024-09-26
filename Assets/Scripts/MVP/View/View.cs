using Game.MVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MVP
{
    public abstract class View : MonoBehaviour
    {
        protected Presenter _precenter;

        [SerializeField] private Text _helthText;

        public virtual void Init(Presenter precenter)
        {
            _precenter = precenter;
        }

        public void UpdateHealth(int damage)
        {
            _helthText.text = $"Damage: {damage}";
        }
    }
}