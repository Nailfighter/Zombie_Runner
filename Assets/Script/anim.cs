using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DASY",10f);
    }

    private void DASY()
    {
        GetComponent<Animator>().enabled = false;
    }

}
