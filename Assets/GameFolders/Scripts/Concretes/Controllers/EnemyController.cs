using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.Movements;
using UdemyProject2.ExtensionMethods;
using UnityEngine;

namespace UdemyProject2.Controller
{
    public class EnemyController : MonoBehaviour
    {
       Mover _mover;
       Health _health;
       Flip _flip;
       Animation _enemyAnimation;
       OnReachedEdge _onReachedEdge;

       bool _isOnEdge;
       float _direction;

       private void Awake()
       {
           _mover = GetComponent<Mover>();
           _health = GetComponent<Health>();
           _flip = GetComponent<Flip>();
           _onReachedEdge = GetComponent<OnReachedEdge>();

           _direction = 1f;
       }

       private void OnEnable()
       {
           _health.OnDead += DeadAction;
       }

       private void FixedUpdate()
       {
           if (_health.IsDead) return;

           _mover.HorizontalMove(_direction);
       }

       private void LateUpdate()
       {
           if(_health.IsDead) return;

           if(_onReachedEdge.ReachedEdge())
           {
                _direction *= -1;
               _flip.FlipPlayer(_direction);
           }
       }

       private void OnCollisionEnter2D(Collision2D collision)
       {
            Damage damage = collision.collider.GetComponent<Damage>();

            if (collision.HasHitPlayeR() && collision.WasHitBottomSide())
                {
                    damage.HitTarget(_health);
                }   
       }

       private void DeadAction()
       {
           Destroy(this.gameObject);
       }
    }
}
