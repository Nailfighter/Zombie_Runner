﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] AudioClip Battery_Sound;
    [SerializeField] bool Ultimate_Battery = false;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Torch>() && !Ultimate_Battery)
        {
            other.GetComponent<Torch>().Increase_Battery_Torch();
            other.GetComponent<AudioSource>().PlayOneShot(Battery_Sound);
            Destroy(gameObject);
        }
        if (other.GetComponent<Torch>() && Ultimate_Battery)
        {
            other.GetComponent<Torch>().Ultimate_torch();
            other.GetComponent<AudioSource>().PlayOneShot(Battery_Sound);
            Destroy(gameObject);
        }
    }
}
