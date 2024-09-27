using UnityEngine;
using Game.MVP;

namespace Characters
{
    public class Player : CharacterSettings, IService
    {
        [SerializeField] private int _maxRerol;

        private int _maxCountRerol;

        private CharacterSettings _enemy;

        private bool _lock = true;

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
            if (_maxRerol > 0 && _lock)
            {
                base.RerolDice();
                _maxRerol--;
                _lock = false;
                Invoke(nameof(UnlockRerol), 2);
            }
        }

        public void UnlockRerol()
        {
            _lock = true;
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
