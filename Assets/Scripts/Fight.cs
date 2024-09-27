using Characters;
using UnityEngine;

namespace Game
{
    public class Fight : MonoBehaviour, IService
    {
        private Enemy _enemy;
        private Player _player;
        private Panels _panels;

        private bool _stepPlayer;
        private bool _gameEnd;

        public void Init()
        {
            _gameEnd = false;
            _stepPlayer = true;
            _enemy = ServiceLocator.Current.Get<Enemy>();
            _player = ServiceLocator.Current.Get<Player>();
            _panels = ServiceLocator.Current.Get<Panels>();
        }

        public void PlayerStep()
        {
            if (!_gameEnd)
            {
                _stepPlayer = false;
                _player.CheckDice(_enemy);
                EnemyStep();
            }
        }

        public void EnemyStep()
        {
            if(!_gameEnd)
                StartCoroutine(_enemy.EnemyAttacked());    
        }

        public void EnemyStepEnd()
        {
            _enemy.AttackDice();
            _enemy.CheckDice(_player);
            _stepPlayer = true;
        }

        public bool CheckStep()
        {
            return _stepPlayer; 
        }

        public void EnemyDie()
        {
            _gameEnd = true;
            _panels.GameWin();
        }

        public void PlayerDie()
        {
            _gameEnd = true;
            _panels.GameLoose();
        }
    }
}
