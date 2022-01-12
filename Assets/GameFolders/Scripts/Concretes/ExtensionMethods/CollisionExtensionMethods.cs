using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Controller;
using UnityEngine;

namespace UdemyProject2.ExtensionMethods
{
    public static class CollisionExtensionMethods
    {
        public static bool WasHitLeftOrRightSide(this Collision2D collision)
        {
            {
                return collision.contacts[0].normal.x > 0.6f || collision.contacts[0].normal.x < -0.6f;
            }
        }

        public static bool WasHitBottomSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.y < -0.6f;
        }

        public static bool WasHitTopSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.y > 0.6f;
        }

        public static bool HasHitPlayeR(this Collision2D collision)
        {
            return collision.collider.GetComponent<PlayerController>() != null;
        }

        public static bool HasHitEnemy(this Collision2D collision)
        {
            return collision.collider.GetComponent<EnemyController>() != null;
        }
    }    
}
