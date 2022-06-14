using CodeMVC.Interface;
using CodeMVC.Weapon;
using UnityEngine;

namespace CodeMVC.Player
{
    public class PlayerAttackController : IExecute
    {
        private readonly PlayerProvider _playerProvider;
        private readonly Transform _playerSwordHolder;

        public PlayerAttackController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
        GameObject player)
        {
            _playerProvider = player.GetComponent<PlayerProvider>();
            _playerSwordHolder = player.transform.Find("sprite").transform.Find("SwordHolder");

            _playerProvider.OnProjectileEnterChange += TakeProjectile;
        }

        private void TakeProjectile(Collision2D other)
        {
            var sword = other.gameObject.GetComponent<SwordProvider>();
            sword.Take(_playerSwordHolder);
        }


        public void Execute(float deltaTime)
        {
        }
    }
}