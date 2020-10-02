using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] Light torch_light;
    [SerializeField] float Min_Spot_Angle, Max_Spot_Angle;
    [SerializeField] float Min_Int, Max_Int;
    [SerializeField] float Dec_Spot, Dec_Int;
    bool decreasing = false;
    [SerializeField] float Decreasing_Speed=1f;

    void Start()
    {
        Initialise_Battery_Torch();
    }



    IEnumerator Angle_Dim_Light()
    {
        while (torch_light.intensity > Min_Int)
        {
            torch_light.intensity -= Dec_Int;
            yield return new WaitForSeconds(2f*1/Decreasing_Speed);
        }
        decreasing = false;
    }
    IEnumerator Spot_Dim_Light()
    {
        while (torch_light.spotAngle> Min_Spot_Angle)
        {
            torch_light.spotAngle -= Dec_Spot;
            yield return new WaitForSeconds(0.5f*1/Decreasing_Speed);
        }
        decreasing = false;
    }

    public void Increase_Battery_Torch()
    {
        //intensity
        if (torch_light.intensity + (Max_Int - Min_Int) / 2>Max_Int)
        {
            torch_light.intensity = Max_Int;
        }
        else
        {
            torch_light.intensity += (Max_Int - Min_Int) / 2;
        }

        //spotangle
        if (
        torch_light.spotAngle + (Max_Spot_Angle - Min_Spot_Angle) / 2>Max_Spot_Angle)
        {
            torch_light.spotAngle = Max_Spot_Angle;
        }
        else
        {

            torch_light.spotAngle += (Max_Spot_Angle - Min_Spot_Angle) / 2;
        }


        if (!decreasing)
        {
            decreasing = true;
            StartCoroutine(Angle_Dim_Light());
            StartCoroutine(Spot_Dim_Light());
        }
    }
    public void Initialise_Battery_Torch()
    {
        torch_light.intensity = Max_Int ;
        torch_light.spotAngle = Max_Spot_Angle;
        StartCoroutine(Angle_Dim_Light());
        StartCoroutine(Spot_Dim_Light());
    }
}
