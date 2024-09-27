using Characters;
using UnityEngine;

namespace Game
{
    public class Fight : MonoBehaviour, IService
    {
        private Enemy _enemy;
        private Player _player;

        private bool StepPlayer;

        public void Init()
        {
            StepPlayer = true;
            _enemy = ServiceLocator.Current.Get<Enemy>();
            _player = ServiceLocator.Current.Get<Player>();
        }

        public void PlayerStep()
        {
            StepPlayer = false;
            _player.CheckDice(_enemy);
            EnemyStep();
        }

        public void EnemyStep()
        {
            StartCoroutine(_enemy.EnemyAttacked());    
        }

        public void EnemyStepEnd()
        {
            _enemy.AttackDice();
            _enemy.CheckDice(_player);
            StepPlayer = true;
        }

        public bool CheckStep()
        {
            return StepPlayer; 
        }

        public void EnemyDie()
        {
            StepPlayer = false;
        }

        public void PlayerDie()
        {
            StepPlayer = false;
        }
    }
}
