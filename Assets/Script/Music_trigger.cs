using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_trigger : MonoBehaviour
{
    [SerializeField] AudioClip Transition_Clip;
    [SerializeField] bool Play_A_Clip = false;
    private void OnTriggerEnter(Collider other)
    {
        if (Play_A_Clip) { Play_A_audio(); return; }
        GetComponentInParent<AudioSource>().clip = Transition_Clip;
        GetComponentInParent<AudioSource>().enabled = false;
        GetComponentInParent<AudioSource>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;
        
    }
    void Play_A_audio()
    {
        AudioSource audio=gameObject.AddComponent<AudioSource>();
        audio.volume = 0.5f;
        audio.loop = false;
        audio.PlayOneShot(Transition_Clip);
        GetComponent<BoxCollider>().enabled = false;
    }
}
