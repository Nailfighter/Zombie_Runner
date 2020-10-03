using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Torch>())
        {
            other.GetComponent<Torch>().Increase_Battery_Torch();
            Destroy(gameObject);
            //PickUp Done
        }
    }
}
