using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    [SerializeField] int Health_P;
    [SerializeField] Slider Health_Slider;
    [SerializeField] GameObject Death_UI;
    public void enemy_hit(int enemy_damage)
    {
        Health_P -= enemy_damage;
        Health_Slider.value = Health_P;
        check_if_dead();
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
