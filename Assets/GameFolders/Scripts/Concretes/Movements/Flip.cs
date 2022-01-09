using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class Flip : MonoBehaviour
    {
        public void FlipPlayer(float horizontal)
        {
            if (horizontal != 0)
            {
                float mathfValue = Mathf.Sign(horizontal);
                if (transform.localScale.x == mathfValue) return;

                transform.localScale = new Vector2 (mathfValue, 1f);
            }
        }
    }
}

