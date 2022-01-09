using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class Climbing : MonoBehaviour
    {
        [SerializeField] float climbSpeed = 3f;

        Rigidbody2D _rigidbody2D;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public bool IsClimbing { get; set; }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void ClimbAction(float direction)
        {
            transform.Translate(Vector2.up * direction * Time.deltaTime * climbSpeed);
        }
    }
}
