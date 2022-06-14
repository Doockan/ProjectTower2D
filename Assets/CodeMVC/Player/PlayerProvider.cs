using System;
using CodeMVC.AssetManagement;
using UnityEngine;

namespace CodeMVC.Player
{
    public class PlayerProvider : MonoBehaviour
    {
        public event Action<bool> OnGroundEnterChange;
        public event Action<Collision2D> OnProjectileEnterChange;

        [SerializeField] private Transform _trajectoryLine;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _throwForce;

        public Transform TrajectoryLine => _trajectoryLine;
        
        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public float ThrowForce => _throwForce;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerName.Ground);
            {
                OnGroundEnterChange?.Invoke(other.gameObject.layer == LayerName.Ground);
            }

            if (other.gameObject.layer == LayerName.Projectile)
            {
                OnProjectileEnterChange?.Invoke(other);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            OnGroundEnterChange?.Invoke(other.gameObject.layer == LayerName.Ground);
        }
    }
}