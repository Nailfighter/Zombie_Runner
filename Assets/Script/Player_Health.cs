using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public PostProcessVolume m_Volume;
    public  Vignette m_Vignette;

    [SerializeField] Color color_blood;
    [SerializeField] int Health_P;
    [SerializeField] Slider Health_Slider;
    [SerializeField] GameObject Death_UI;
    private void Start()
    {
        Instantiat_Quick_Volume();
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
        Death_UI.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
    }
}
