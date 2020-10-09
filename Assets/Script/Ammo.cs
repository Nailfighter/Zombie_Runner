using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [System.Serializable]
    private class Ammo_Slots
    {
        public Ammo_Types Ammo_Types;
        public int Total_Ammo;
    }

    [SerializeField] Ammo_Slots[] ammo_Slot;

    [SerializeField] Text Ammo_Text;

    

    private Ammo_Slots Get_Ammo_Slot(Ammo_Types ammo_Type)
    {
        foreach(Ammo_Slots slot in ammo_Slot)
        {
            if (slot.Ammo_Types == ammo_Type)
            {
                return slot;
            }
        }
        return null;
    }
    public int Ammo_Left(Ammo_Types ammo_Type)
    {
        return Get_Ammo_Slot(ammo_Type).Total_Ammo;
    }
    public void Reduce_Ammo(Ammo_Types ammo_Type)
    {
        Get_Ammo_Slot(ammo_Type).Total_Ammo--;
        Ammo_Display(ammo_Type);
    }
    public void Increase_Ammo(Ammo_Types ammo_Type, int Increase_in_ammo)
    {
        Get_Ammo_Slot(ammo_Type).Total_Ammo+=Increase_in_ammo;
        Ammo_Display(ammo_Type);
    }

    public void Ammo_Display(Ammo_Types ammo_Type)
    {
        Ammo_Text.text = Get_Ammo_Slot(ammo_Type).Total_Ammo.ToString();
    }
}
