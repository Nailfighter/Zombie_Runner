using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Player_Related_Audio : MonoBehaviour
{
    [SerializeField] AudioClip Hit_Sound_Clip;
    public AudioSource FootStep_Source;
    public AudioSource PlayAShot_Source;
    bool Foot_On = false;

    public void Update()
    {
        if (GetComponentInParent<RigidbodyFirstPersonController>().Grounded && GetComponentInParent<Rigidbody>().velocity.magnitude > 2)
        {
            if (Foot_On) { return; }
            FootStep_Source.Play();
            FootStep_Source.pitch = Random.Range(0.7f, 1f);
            Foot_On = true;
        }
        else
        {
            FootStep_Source.Stop();
            Foot_On = false;
        }
    }

    public void Hit_Sound()
    {
        PlayAShot_Source.PlayOneShot(Hit_Sound_Clip);
    }


}