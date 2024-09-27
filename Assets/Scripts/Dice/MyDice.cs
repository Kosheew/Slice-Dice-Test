using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceController
{
    public class MyDice : MonoBehaviour, IService
    {
        public List<Dice> DiceList;

        public void Init()
        {
            foreach (var dice in DiceList)
            {
                dice.Init();
            }
        }
    }
}
