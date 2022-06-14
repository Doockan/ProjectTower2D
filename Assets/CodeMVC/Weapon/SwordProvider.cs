using System;
using UnityEngine;

namespace CodeMVC.Weapon
{
    public class SwordProvider : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private CapsuleCollider2D _collider2D;
        private Transform _point;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<CapsuleCollider2D>();
            _point = transform.Find("point");
        }

        public void Take(Transform point)
        {
            transform.parent = point.parent;
            transform.position = point.position;
            transform.rotation = point.rotation;
            _collider2D.enabled = false;
            Destroy(_rigidbody2D);
        }

        public void Throw(Vector2 direction, float force)
        {
            
        }
    }
}