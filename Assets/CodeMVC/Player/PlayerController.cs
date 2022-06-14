using CodeMVC.Interface;
using CodeMVC.StateMachines;
using CodeMVC.StateMachines.PlayerState;
using UnityEngine;

namespace CodeMVC.Player
{
    public sealed class PlayerController: IExecute, ILateExecute, ICleanup
    {
        private readonly IUserInputProxy _horizontalInputProxy;
        private readonly IUserInputProxy _verticalInputProxy;

        private float _horizontal;
        private float _vertical;

        public PlayerProvider PlayerProvider;
        private Rigidbody2D _rigidbody2D;

        public StateMachine movementSM;
        public StandingState standing;
        public JumpingState jumping;
        public DeadEyeState deadEye;


        public PlayerController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, GameObject player, GameObject line)
        {
            PlayerProvider = player.GetComponent<PlayerProvider>();
            _rigidbody2D = PlayerProvider.GetComponent<Rigidbody2D>();
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy = input.inputHorizontal;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            
            movementSM = new StateMachine();
            standing = new StandingState(this, movementSM, (_horizontalInputProxy, _verticalInputProxy));
            jumping = new JumpingState(this, movementSM, (_horizontalInputProxy, _verticalInputProxy));
            deadEye = new DeadEyeState(this, movementSM,(_horizontalInputProxy, _verticalInputProxy), line);
            movementSM.Initialize(standing);
        }

        public void Execute(float deltaTime)
        {
            movementSM.CurrentState.HandleInput();
            movementSM.CurrentState.LogicUpdate();
        }

        public void LateExecute(float deltaTime)
        {
            movementSM.CurrentState.PhysicsUpdate();
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }

        public void Move()
        {
            _rigidbody2D.velocity = new Vector2(Mathf.Round(_horizontal) * PlayerProvider.Speed, _rigidbody2D.velocity.y);
        }

        public void Jump()
        {
            _rigidbody2D.velocity += Vector2.up * PlayerProvider.JumpForce;
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