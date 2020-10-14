using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Script
{
    public class Extra_Control : MonoBehaviour
    {
        public bool Is_Game_Paused = false;
        private void Start()
        {
            Time.timeScale = 1f;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}