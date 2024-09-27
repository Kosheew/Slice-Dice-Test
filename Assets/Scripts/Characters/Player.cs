using UnityEngine;
using Game.MVP;

namespace Characters
{
    public class Player : CharacterSettings, IService
    {
        [SerializeField] private int _maxRerol;

        private int _maxCountRerol;

        private CharacterSettings _enemy;

        public int CountRerol
        {
            private set { _maxRerol = value; }
            get { return _maxRerol; } 
        }

        public override void Init(Presenter presenter)
        {
            base.Init(presenter);
            _maxCountRerol = _maxRerol;
            _enemy = ServiceLocator.Current.Get<Enemy>();
        }

        public override void RerolDice()
        {
            if (_maxRerol > 0 && _dice.RbDice.velocity == Vector3.zero)
            {
                base.RerolDice();

                _maxRerol--;
            }
        }

        public override void AttackDice()
        {
            base.AttackDice();

            _maxRerol = _maxCountRerol;

            _fight.PlayerStep();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if (_health <= 0)
            {
                _fight.PlayerDie();
            }
        }
    }
} 
