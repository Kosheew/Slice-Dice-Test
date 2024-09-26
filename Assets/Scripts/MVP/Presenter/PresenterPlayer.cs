using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterSettings;

namespace Game.MVP
{
    public class PresenterPlayer : Presenter
    {
        public PresenterPlayer(Character character, View view) : base(character, view)
        {

        }
        public override void SetAttack()
        {
            throw new System.NotImplementedException();
        }

        public override void ShakeDice()
        {
            throw new System.NotImplementedException();
        }
    }
}