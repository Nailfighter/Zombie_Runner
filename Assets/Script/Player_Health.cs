using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player_Health : MonoBehaviour
{
    PostProcessVolume m_Volume;
    Vignette m_Vignette;
    public Game_Data Data;
    [SerializeField] Color color_blood;
    [SerializeField] int Health_P;
    [SerializeField] Slider Health_Slider;
    [SerializeField] GameObject Death_UI;
    Torch torch;
    private void Start()
    {
        torch = GetComponent<Torch>();
        Instantiat_Quick_Volume();
        Health_Definer();

    }

    private void Health_Definer()
    {
        switch (Data.Difficulty)
        {
            default:
                Health_P = 1000;
                torch.Decreasing_Speed = 0.3f;
                break;
            case Game_Data.mode.Beginner:
                Health_P = 1000;
                torch.Decreasing_Speed = 0.3f;
                break;

            case Game_Data.mode.Amateur:
                Health_P = 700;
                torch.Decreasing_Speed = 0.6f;
                break;

            case Game_Data.mode.Nightmare:
                Health_P = 400;
                torch.Decreasing_Speed = 1f;
                break;  
        }
        Health_Slider.maxValue = Health_P;
        Health_Slider.value = Health_P;
    }

    public void enemy_hit(int enemy_damage)
    {
        Health_P -= enemy_damage;
        StartCoroutine(Post_Processsing_Hit());
        Health_Slider.value = Health_P;
        check_if_dead();
    }

    IEnumerator Post_Processsing_Hit()
    {
        m_Vignette.enabled.Override(true);
        yield return new WaitForSeconds(1f);
        m_Vignette.enabled.Override(false);
    }

    private void Instantiat_Quick_Volume()
    {
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.intensity.Override(0.4f);
        m_Vignette.color.Override(color_blood);
        m_Vignette.smoothness.Override(1f);
        m_Vignette.roundness.Override(1f);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    }

    void check_if_dead()
    {
        if (Health_P <= 0)
        {
            StartCoroutine(End_Game());
        }
    }

    IEnumerator End_Game()
    {
        FindObjectOfType<RigidbodyFirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


        Death_UI.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }
}
