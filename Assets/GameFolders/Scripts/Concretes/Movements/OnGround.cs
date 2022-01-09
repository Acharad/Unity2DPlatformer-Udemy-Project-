using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] bool isOnGround = false;
        [SerializeField] float maxDistance = 0.15f;
        [SerializeField] LayerMask layerMask;
        [SerializeField] Transform[] translates;

        public bool IsOnGround => isOnGround;

        private void Update()
        {
            foreach (Transform footTransform in translates)
            {
                CheckFootOnGround(footTransform);

                if (isOnGround) break;
            }
        }

        private void CheckFootOnGround(Transform footTransform)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, layerMask);
            //Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);

            if (hit.collider != null)
            {
                isOnGround = true;
            }
            else
            {
                isOnGround = false;
            }
        }
    }
}
