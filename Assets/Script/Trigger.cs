using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    [SerializeField] GameObject panel;
    private void OnTriggerEnter(Collider other)
    {
        panel.SetActive(true);
        Invoke("Credit", 5f);
    }
    void Credit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
