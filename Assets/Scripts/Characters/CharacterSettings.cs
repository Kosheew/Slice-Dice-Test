using DiceController;
using Game;
using Game.MVP;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

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
                else if (value > _maxDefence)
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
        protected Dice _dice;
        protected Presenter _presenter;
        protected AudioSource _audioSource;
        protected Animator _animator;

        public virtual void Init(Presenter presenter)
        {
            _health = _stats.Health;
            _defence = _stats.Defence;
            _clipAttack = _stats.AudioAttack;

            _maxHealth = _health;
            _maxDefence = _defence;
            _presenter = presenter;

            _dice = ServiceLocator.Current.Get<Dice>();
            _fight = ServiceLocator.Current.Get<Fight>();
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();

            _presenter.SetDefence();
            _presenter.SetHealth();
        }

        public virtual void RerolDice()
        {
            _dice.Rerol();
        }

        public virtual void AttackDice()
        {
            _audioSource.PlayOneShot(_clipAttack);
            _animator.SetTrigger("isAttacked");        
        }
        
        public void CheckDice(CharacterSettings character)
        {
            if (_dice.CurrentType == SideTypes.Health)
            {
                Health += _dice.PowerAttack;
                _presenter.SetHealth();
            }
            else if (_dice.CurrentType == SideTypes.Protection)
            {
                Defence += _dice.PowerAttack;
                _presenter.SetDefence();
            }
            else if (_dice.CurrentType == SideTypes.Attack)
            {
                character.TakeDamage(_dice.PowerAttack);
            }
        }

        public virtual void TakeDamage(int damage)
        {
            if(_defence > 0)
            {
                Defence -= damage;
                _presenter.SetDefence();
                return;
            }

            Health-= damage;
            _presenter.SetHealth();
            if (_health <= 0) 
            {
                _animator.SetTrigger("isDead");
            }
        } 
    }
} 
 