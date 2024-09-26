using DiceController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSettings
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private int _health;
        
        private int _maxHealth;

        [SerializeField] private Dice _dice;

        protected void Awake()
        {
            _maxHealth = _health;
        }

        public void RerolDice()
        {
            _dice.Rerol();
        }

        public void AttackDice()
        {
            _dice.Attack();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            _health = Mathf.Clamp(_health, 0, _maxHealth);

            if(_health <= 0)
            {
                Debug.Log("Die");
            }
        } 
    }
} 
 