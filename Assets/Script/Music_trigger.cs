using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_trigger : MonoBehaviour
{
    [SerializeField] AudioClip Transition_Clip;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Music_Player>().GetComponent<AudioSource>().clip = Transition_Clip;
        FindObjectOfType<Music_Player>().GetComponent<AudioSource>().enabled = false;
        FindObjectOfType<Music_Player>().GetComponent<AudioSource>().enabled = true;
    }
}
