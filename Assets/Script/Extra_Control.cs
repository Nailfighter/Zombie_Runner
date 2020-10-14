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
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                //Time.timeScale = 0f;
                FindObjectOfType<RigidbodyFirstPersonController>().enabled = false;

                
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(0);
            }
        }

        void Anim_Vover()
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<RigidbodyFirstPersonController>().enabled = true;
            print("Anim Vover");

        }
        void Anim_Start()
        {
            GetComponent<RigidbodyFirstPersonController>().enabled=false;
            Invoke("Anim_Vover", 12.5f);
        }
    }
}