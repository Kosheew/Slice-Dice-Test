using CharacterSettings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MVP
{
    public class PresenterEnemy : Presenter
    {
        public PresenterEnemy(Character character, View view) : base(character, view)
        {
          
        }
        public override void ShakeDice()
        {
            throw new System.NotImplementedException();
        }

        public override void SetAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}