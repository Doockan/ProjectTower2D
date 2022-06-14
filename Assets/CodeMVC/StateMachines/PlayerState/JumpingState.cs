using CodeMVC.Interface;
using CodeMVC.Player;
using UnityEngine;

namespace CodeMVC.StateMachines.PlayerState
{
    public class JumpingState : State
    {
        private bool _isGround;

        public JumpingState(PlayerController player, StateMachine stateMachine, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input) : base(player, stateMachine, input)
        {
            player.PlayerProvider.OnGroundEnterChange += CheckGroundOverlap;
        }

        public override void Enter()
        {
            base.Enter();
            _isGround = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGround)
            {
                _stateMachine.ChangeState(Player.standing);
            }
            if (Input.GetMouseButtonUp(0))
            {
                _stateMachine.ChangeState(Player.deadEye);
            }
        }
        
        private void CheckGroundOverlap(bool ground)
        {
            _isGround = ground;
        }
    }
}