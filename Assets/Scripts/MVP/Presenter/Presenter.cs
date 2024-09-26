using CharacterSettings;
using UnityEngine;

namespace Game.MVP
{
    public abstract class Presenter 
    {
        protected Character _characterModel;
        protected View _view;

        public Presenter(Character character, View view)
        {
            _characterModel = character;
            _view = view;
            _view.Init(this);
        }

        public abstract void ShakeDice();

        public abstract void SetAttack();
    }
}
