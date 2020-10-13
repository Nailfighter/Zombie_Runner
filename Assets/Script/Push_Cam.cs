using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Cam : MonoBehaviour
{
    [SerializeField] float Speed_Cofficient=1f;
    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    public void Update()
    {
        rigidbody.AddRelativeForce(Vector3.forward * Speed_Cofficient * Time.deltaTime);
        transform.Rotate(Vector3.forward *Speed_Cofficient * Time.deltaTime);
    }
}
