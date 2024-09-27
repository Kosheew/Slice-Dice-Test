using DiceController;
using Game;
using Game.MVP;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public abstract class CharacterSettings : MonoBehaviour
    {
        [SerializeField] private CharactersStats _stats;

        protected int _health;
        protected int _defence;
        private AudioClip _clipAttack;

        private int _maxHealth;
        private int _maxDefence;

        public int Health
        {
            get { return _health; }
            set { 
                if(value <= 0)
                {
                    _health = 0; 
                } 
                else if (value > _maxHealth)
                {
                    _health = _maxHealth;
                }
                else
                {
                    _health = value;
                }
            } 
        }

        public int Defence
        {
            get { return _defence; }
            set
            {
                if (value <= 0)
                {
                    _defence = 0;
                }
                else if (value > _maxDefence)
                {
                    _defence = _maxDefence;
                }
                else
                {
                    _defence = value;
                }
            }
        }

        protected Fight _fight;
        protected MyDice _dice;
        protected Presenter _presenter;
        protected AudioSource _audioSource;
        protected Animator _animator;

        protected List<Dice> _diceList;

        public virtual void Init(Presenter presenter)
        {
            _health = _stats.Health;
            _defence = _stats.Defence;
            _clipAttack = _stats.AudioAttack;

            _maxHealth = _health;
            _maxDefence = _defence;
            _presenter = presenter;

            _dice = ServiceLocator.Current.Get<MyDice>();
            _fight = ServiceLocator.Current.Get<Fight>();
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();

            _diceList = _dice.DiceList;

            _presenter.SetDefence();
            _presenter.SetHealth();
        }

        public virtual void RerolDice()
        {
            foreach (var dice in _diceList)
            {
                dice.Rerol();
            }
        }

        public virtual void AttackDice()
        {
            _audioSource.PlayOneShot(_clipAttack);
            _animator.SetTrigger("isAttacked");        
        }

        public void CheckDice(CharacterSettings character)
        {
            foreach (var dice in _diceList)
            {
                if (dice.CurrentType == SideTypes.Health)
                {
                    Health += dice.PowerAttack;
                    _presenter.SetHealth();
                }
                else if (dice.CurrentType == SideTypes.Protection)
                {
                    Defence += dice.PowerAttack;
                    _presenter.SetDefence();
                }
                else if (dice.CurrentType == SideTypes.Attack)
                {
                    character.TakeDamage(dice.PowerAttack);
                }

            }
        }

        public virtual void TakeDamage(int damage)
        {
            int currentDefence = Defence;

            if(_defence > 0)
            {
                currentDefence -= damage;
                if (currentDefence < 0)
                {
                    Health += currentDefence;
                    _presenter.SetHealth();
                    currentDefence = 0;
                }
                Defence = currentDefence;
                _presenter.SetDefence();
                return;
            }

            Health -= damage;
            _presenter.SetHealth();
            if (_health <= 0) 
            {
                _animator.SetTrigger("isDead");
            }
        } 
    }
} 
 