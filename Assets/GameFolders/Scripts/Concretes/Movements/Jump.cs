using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] float jumpForce;

        Rigidbody2D _rigidbody2D;

        public bool IsJumpAction => _rigidbody2D.velocity != Vector2.zero;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        public void JumpAction(float jumpForce = 400f)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
