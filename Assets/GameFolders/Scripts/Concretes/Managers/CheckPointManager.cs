using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UdemyProject2.Controller;
using UdemyProject2.Combats;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class CheckPointManager : MonoBehaviour
    {
        CheckpointController[] _checkpointController;
        Health _health;

        private void Awake()
        {
            _checkpointController = GetComponentsInChildren<CheckpointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        }

        private void Start()
        {
            _health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged()
        {
            _health.transform.position = _checkpointController.LastOrDefault(x => x.IsPassed).transform.position; 
        }
    }
}

