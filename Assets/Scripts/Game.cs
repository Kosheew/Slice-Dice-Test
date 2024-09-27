using UnityEngine;
using DiceController;
using Characters;
using Game.MVP;

namespace Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Player _player;

        [SerializeField] private ViewEnemy _viewEnemy;
        [SerializeField] private ViewPlayer _viewPlayer;

        [SerializeField] private Fight _fight;
        [SerializeField] private MyDice _dice;

        [SerializeField] private Panels _panels;

        private Presenter _presenterEnemy;
        private Presenter _presenterPlayer;

        private void Awake()
        {
            Register();

            _presenterEnemy = new PresenterEnemy(_enemy, _viewEnemy);
            _presenterPlayer = new PresenterPlayer(_player, _viewPlayer);


            _dice.Init();
            _player.Init(_presenterPlayer);
            _enemy.Init(_presenterEnemy);
            _panels.Init();
            _fight.Init();
        }

        private void Register()
        {
            ServiceLocator.Initialize();

            ServiceLocator.Current.Register(_dice);
            ServiceLocator.Current.Register(_enemy);
            ServiceLocator.Current.Register(_player);
            ServiceLocator.Current.Register(_panels);
            ServiceLocator.Current.Register(_fight);
        }
    }
}
