using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Controller;
using UnityEngine;

namespace UdemyProject2.Observers
{
    public class SoundObserver : MonoBehaviour
    {
        AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerController.OnPlayerDead += PlaySoundOneShot;
            EnemyController.OnEnemyDead += PlaySoundOneShot;
            ScoreController.OnScoreSound += PlaySoundOneShot;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayerDead -= PlaySoundOneShot;
            EnemyController.OnEnemyDead -= PlaySoundOneShot;
            ScoreController.OnScoreSound -= PlaySoundOneShot;
        }

        private void PlaySoundOneShot(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }    
}
