using CodeMVC.Interface;
using UnityEngine;

namespace CodeMVC.Player
{
    public class PlayerRotateController : IExecute, ICleanup
    {
        private readonly GameObject _player;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly IUserInputProxy _horizontalInputProxy;
        private float _horizontal;


        public PlayerRotateController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            GameObject player)
        {
            _horizontalInputProxy = input.inputHorizontal;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            
            _player = player;
            _spriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        }


        public void Execute(float deltaTime)
        {
            if (_horizontal > 0f)
            {
                _spriteRenderer.transform.localScale = new Vector2(1, 1);
            }
            else if (_horizontal < 0f)
            {
                _spriteRenderer.transform.localScale = new Vector2(-1, 1);
            }
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }
    }
}