using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    bool door_opened=false;
    [SerializeField] bool is_door_1 = true;
    public void Anim_Sound()
    {
        GetComponent<AudioSource>().Play();
    }
    public void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enle0").Count()==0 && !door_opened && is_door_1)
        {
            print("Open Door");
            GetComponent<Animator>().SetBool("Door_Open", true);
            door_opened = true;
        }
        if (GameObject.FindGameObjectsWithTag("Enle-123").Count() == 0 && !door_opened && !is_door_1)
        {
            print("Open Door");
            GetComponent<Animator>().SetBool("Door_Open", true);
            door_opened = true;
        }

    }
}
