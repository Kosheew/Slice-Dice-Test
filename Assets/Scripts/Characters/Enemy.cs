using Game.MVP;
using UnityEngine;
using System.Collections;

namespace Characters
{
    public class Enemy : CharacterSettings, IService
    {
        private CharacterSettings _player;

        public override void Init(Presenter presenter)
        {
            base.Init(presenter);
            _player = ServiceLocator.Current.Get<Player>();
        }

        public override void AttackDice()
        {
            base.AttackDice();    
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if(_health <= 0)
            {
                _fight.EnemyDie();
            }
        }

        public IEnumerator EnemyAttacked()
        {
            yield return new WaitForSeconds(3);
            RerolDice();
            yield return new WaitForSeconds(3);
            _fight.EnemyStepEnd();
            yield break;
        }
    }
}