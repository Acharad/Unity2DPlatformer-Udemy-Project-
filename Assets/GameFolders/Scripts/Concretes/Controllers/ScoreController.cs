using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UdemyProject2.Uis;
using UnityEngine;

namespace UdemyProject2.Controller
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] int score = 1;
        [SerializeField] AudioClip scoreClip;

        public static event System.Action<AudioClip> OnScoreSound;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if(player != null)
            {
                GameManager.Instance.IncreaseScore(score);
                OnScoreSound.Invoke(scoreClip);
                Destroy(this.gameObject);
            }
        }
    }    
}
