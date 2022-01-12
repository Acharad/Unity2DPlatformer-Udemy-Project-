using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Inputs;
using UdemyProject2.Movements;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.Uis;
using UdemyProject2.ExtensionMethods;
using UnityEngine;


namespace UdemyProject2.Controller
{
    public class PlayerController : MonoBehaviour
    {
        
        
        float _vertical;
        float _horizontal;
        bool _isJump;

        Animator _animator;
        PcInput _input;
        Mover _mover;
        Jump _jump;
        PlayerAnimation _playerAnimation;
        Flip _playerflip;
        OnGround _onGround;
        Climbing _climbing;
        Health _health;

        private void Awake()
        {
            _input = new PcInput(); //instance yeni sınıf kullanılıyor.
            
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _playerAnimation = GetComponent<PlayerAnimation>();
            _playerflip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _climbing = GetComponent<Climbing>();
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

            if(gameCanvas != null)
            {
                _health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                _health.OnHealthChanged += displayHealth.WriteHealth;
            }
        }

        private void Update()
        {
            if(_health.IsDead) return;
            
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJumpButtonDown && _onGround.IsOnGround && !_climbing.IsClimbing)
            {
                _isJump = true;
            }

            _playerAnimation.MoveAnimation(_horizontal);
            _playerAnimation.JumpAnimation(!_onGround.IsOnGround && _jump.IsJumpAction);
            _playerAnimation.ClimbAnimation(_climbing.IsClimbing);
        }

        private void FixedUpdate()
        {
            _mover.HorizontalMove(_horizontal);
            if(_climbing.IsClimbing)
            {
                _climbing.ClimbAction(_vertical);
            }
            _playerflip.FlipPlayer(_horizontal);


            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();

            if (collision.HasHitEnemy() && collision.WasHitLeftOrRightSide())
            {
                damage.HitTarget(_health);
                return;
            }

            if(damage != null && !collision.HasHitEnemy())
            {
                damage.HitTarget(_health);
            }
        }
    }
}
