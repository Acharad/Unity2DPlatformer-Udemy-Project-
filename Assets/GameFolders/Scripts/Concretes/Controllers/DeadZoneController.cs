using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Combats;
using UdemyProject2.ExtensionMethods;
using UnityEngine;

namespace UdemyProject2.Controller
{
    public class DeadZoneController : MonoBehaviour
    {
        Damage _damage;

        private void Awake()
        {
            _damage = GetComponent<Damage>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();

            if(health != null)
            {
                health.TakeHit(_damage);
            }
        }
    }    
}
