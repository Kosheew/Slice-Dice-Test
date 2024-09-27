using Characters;

namespace Game.MVP
{
    public class PresenterPlayer : Presenter
    {
        private Player _playerModel;
        private ViewPlayer _viewPlayer;
        private Fight _fight;

        public PresenterPlayer(Player character, ViewPlayer view ) : base( character, view )
        {
            _playerModel = character;
            _viewPlayer = view;
            _viewPlayer.UpdateCountRerol(_playerModel.CountRerol);
            _fight = ServiceLocator.Current.Get<Fight>();
        }

        public override void ShakeDice()
        {
            if (_fight.CheckStep())
            {
                base.ShakeDice();
                _viewPlayer.UpdateCountRerol(_playerModel.CountRerol);
            }
        }

        public override void SetAttack()
        {
            if (_fight.CheckStep())
            {
                base.SetAttack();
                _viewPlayer.UpdateCountRerol(_playerModel.CountRerol);
            }
        }
    }
}