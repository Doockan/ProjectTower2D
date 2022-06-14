using CodeMVC.Controller;
using CodeMVC.Interface;
using CodeMVC.Player;
using UnityEngine;

namespace CodeMVC.StateMachines.PlayerState
{
    public class StandingState : GroundedState
    {
        private bool _crounch;

        private float _horizontal;
        private float _vertical;

        public StandingState(PlayerController player, StateMachine stateMachine,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input) : base(player, stateMachine, input)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            
            speed = Player.PlayerProvider.Speed;
            _crounch = false;
        }

        public override void Exit()
        {
            base.Exit();
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if (_vertical > 0.7f)
            {
                Player.Jump();
                _stateMachine.ChangeState(Player.jumping);
            }
            if (Input.GetMouseButtonUp(0))
            {
                _stateMachine.ChangeState(Player.deadEye);
            }
        }

        public override void LogicUpdate()
        {
        }


        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }
    }
}