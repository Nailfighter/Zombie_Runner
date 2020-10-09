using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Switcher : MonoBehaviour
{
    [SerializeField] int Current_Weapon=0;
    [SerializeField] Transform weapon_display;
    private void Start()
    {
        Switch_Weapon();
    }
    private void Update()
    {
        if (!Input.GetMouseButton(1))
        {
            Scroll_Input();
            Num_Input();
        }
    }

    void Switch_Weapon()
    {
        int Weapon_Index = 0;
        foreach(Transform Weapon in transform)
        {
            if (Weapon_Index == Current_Weapon)
            {
                Weapon.transform.gameObject.SetActive(true);
                FindObjectOfType<Ammo>().Ammo_Display(Weapon.transform.gameObject.GetComponent<Weapon>().Ammo_Type);
            }
           else
            {
                Weapon.transform.gameObject.SetActive(false);
            }
            Weapon_Index++;
        }
        Weapon_Index = 0;
        foreach (Transform Weapon_Pic in weapon_display)
        {
            if (Weapon_Index == Current_Weapon)
            {
                Weapon_Pic.gameObject.SetActive(true);
            }
            else
            {
                Weapon_Pic.gameObject.SetActive(false);
            }
            Weapon_Index++;
        }

    }

    void Scroll_Input()
    {
         // Todo-Zoom and Weapon switch Confict
        float Raw_Scroll_Value = Input.GetAxis("Mouse ScrollWheel");
        if (Raw_Scroll_Value < 0)
        {
            Current_Weapon = Mathf.Clamp(Current_Weapon+1, 0, 2);
        }
        if (Raw_Scroll_Value > 0)
        {
            Current_Weapon = Mathf.Clamp(Current_Weapon-1, 0, 2);
        }
        Switch_Weapon();
    }
    void Num_Input()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Current_Weapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Current_Weapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Current_Weapon = 2;
        }
        Switch_Weapon();
    }
}
