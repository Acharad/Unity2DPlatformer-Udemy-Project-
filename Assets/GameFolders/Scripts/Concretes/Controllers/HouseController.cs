using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Controller
{
    public class HouseController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                GameManager.Instance.LoadScene();
            }
        }
    }
}
