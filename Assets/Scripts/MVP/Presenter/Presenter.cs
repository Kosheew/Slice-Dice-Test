using Characters;

namespace Game.MVP
{
    public abstract class Presenter 
    {
        protected CharacterSettings _characterModel;
        protected View _view;

        public Presenter(CharacterSettings character, View view)
        {
            _characterModel = character;
            _view = view;
            _view.Init(this);
        }

        public virtual void ShakeDice()
        {
            _characterModel.RerolDice();
        }

        public virtual void SetAttack()
        {
            _characterModel.AttackDice();
        }

        public virtual void SetHealth()
        {
            _view.UpdateHealth(_characterModel.Health);
        }

        public virtual void SetDefence()
        {
            _view.UpdateDefence(_characterModel.Defence);
        }
    }
}
