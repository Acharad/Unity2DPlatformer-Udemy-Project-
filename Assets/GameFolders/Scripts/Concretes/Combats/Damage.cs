using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int damage;

        public int HitDamage => damage;

        public void HitTarget(Health health)
        {
            health.TakeHit(this);
        }
    }
}