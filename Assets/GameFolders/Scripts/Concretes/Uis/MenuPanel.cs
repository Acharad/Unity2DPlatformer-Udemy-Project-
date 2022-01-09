using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButtonClick()
        {
            GameManager.Instance.LoadScene(1);
        }

        public void ExitButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
