using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_PickUp : MonoBehaviour
{
    [SerializeField] Ammo_Types ammo_Type;
    [SerializeField] int Total_Ammo_in_Clip=10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ammo>())
        {
            other.GetComponent<Ammo>().Increase_Ammo(ammo_Type, Total_Ammo_in_Clip);
            Destroy(gameObject);
        }
    }
}
