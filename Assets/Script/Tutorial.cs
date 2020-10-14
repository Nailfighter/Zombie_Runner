using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Tutorial : MonoBehaviour
{
    public Game_Data Data;
    public GameObject[] Hints;
    public GameObject Main;
    bool tutorial_done = false;
    int count = 0;
    bool is_light = true;
    public GameObject light;
    private void Update()
    {
        if (count <=5 && !tutorial_done)
        {
            Hint();
            if (FindObjectOfType<Weapon_Zoomer>()) { FindObjectOfType<Weapon_Zoomer>().enabled = false; }
            
        }
        else
        {
            Main.SetActive(false);
            if (FindObjectOfType<Weapon_Zoomer>()) { FindObjectOfType<Weapon_Zoomer>().enabled = true; } 
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            Light_Toggle();
        }

        

    }

    private void Hint()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Hints[count].SetActive(false);
            count++;
            if (count == 6) { tutorial_done = true; return; }
            Hints[count].SetActive(true);
        }
    }
    public void Light_Toggle()
    {
        is_light = !is_light;
        light.SetActive(is_light);
    }
    public void Sensitivity_Changer(float level)
    {
        Data.Sensitivity = level;
        if (FindObjectOfType<Weapon_Zoomer>()) { FindObjectOfType<Weapon_Zoomer>().Mouse_sensitivity_Value(); ; }
    }
}
