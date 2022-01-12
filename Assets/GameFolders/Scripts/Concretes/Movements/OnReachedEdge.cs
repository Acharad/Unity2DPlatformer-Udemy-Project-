using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    [RequireComponent(typeof(Collider2D))]
    public class OnReachedEdge : MonoBehaviour
    {
        [SerializeField] LayerMask layerMask;
        [SerializeField] float distance = 0.1f;

        Collider2D _collider;
        float _xDirection;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _xDirection = 1f;
        }

        public bool ReachedEdge()
        {
            float x = GetForwardXPosition();
            float y = _collider.bounds.min.y;

            Vector2 origin = new Vector2(x, y);

            Debug.DrawRay(origin, Vector2.down * distance ,Color.red);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, layerMask);

            if(hit.collider != null) return false;

            SwitchControlDirection();
            return true;
        }

        private float GetForwardXPosition()
        {
            return _xDirection == -1 ? _collider.bounds.min.x - 0.1f : _collider.bounds.max.x + 0.1f;
        }

        private void SwitchControlDirection()
        {
            _xDirection *= -1;
        }
    }
}
