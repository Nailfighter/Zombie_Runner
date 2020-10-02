using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] GameObject Final_Pos;
    void Update ()
    {
        Vector3 direction = (Final_Pos.transform.position - transform.position).normalized;
        Quaternion To_look = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, To_look, 10* Time.deltaTime);
    }
}
