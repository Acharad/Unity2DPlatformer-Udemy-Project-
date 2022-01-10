using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void RestartGameClick()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void ReturnMenuButtonClick()
        {
            GameManager.Instance.LoadMenuScene();
        }
    }  
}

