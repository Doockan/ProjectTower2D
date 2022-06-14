using CodeMVC.Interface;
using CodeMVC.Player;
using UnityEngine;

namespace CodeMVC.StateMachines.PlayerState
{
    public class DeadEyeState : State
    {
        private readonly PlayerController _player;
        private readonly TrajectoryRenderer _line;
        private float _horizontal;
        private float _vertical;

        public DeadEyeState(PlayerController player, StateMachine stateMachine, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, GameObject line) : base(player, stateMachine, input)
        {
            _player = player;
            _line = line.GetComponent<TrajectoryRenderer>();
            _line.gameObject.SetActive(false);
        }

        public override void Enter()
        {
            base.Enter();
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.02f * 0.1f;
            
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;

        }

        public override void Exit()
        {
            base.Exit();
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;

        }

        public override void HandleInput()
        {
            AimAndShoot();
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void AimAndShoot()
        {
            if (Input.GetMouseButton(0))
            {
                _line.gameObject.SetActive(true);
                var direction = new Vector2(_horizontal * _player.PlayerProvider.ThrowForce, _vertical * _player.PlayerProvider.ThrowForce);
                _line.ShowTrajectory(Player.PlayerProvider.TrajectoryLine.position, direction);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _line.gameObject.SetActive(false);
                _stateMachine.ChangeState(Player.standing);
            }
        }
    }
}