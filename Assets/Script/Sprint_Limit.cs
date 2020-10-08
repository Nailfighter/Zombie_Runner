using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Utility;

public class Sprint_Limit : MonoBehaviour
{
    float inc = 10f;
    public  float Use_Sprint_Speed = 1f;
    public float Recover_Sprint_Speed = 1f;
    RigidbodyFirstPersonController FPS;
    int Bar_Value = 100;
    Slider Sprint_Slider;
    public bool is_sprinting = false;
    private void Start()
    {
        inc = 1;
        FPS = FindObjectOfType<RigidbodyFirstPersonController>();
        Sprint_Slider = GetComponent<Slider>();
    }
    private void Update()
    {
        Bar_Value = Mathf.RoundToInt(Mathf.Lerp(0, 100, inc));
        Sprint_Slider.value = Bar_Value;
        sprint();
    }
    void sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!is_sprinting && FPS.movementSettings.Can_Sprint)
            {
                StopAllCoroutines();
                StartCoroutine(Use_Sprint());
                is_sprinting = true;
            }

        }
        else
        {
            if (is_sprinting)
            {
                StopAllCoroutines();
                StartCoroutine(Regain_Sprint());
                is_sprinting = false;
            }
        }
    }
    IEnumerator Regain_Sprint ()
    {
        while (inc<1)
        {
            inc += 0.1f;
            yield return new WaitForSeconds(1/Recover_Sprint_Speed);
        }
        print("Full recover");
        FPS.movementSettings.Can_Sprint = true;

    }
    public IEnumerator Use_Sprint()
    {
        
        while (inc > 0)
        {
            print("using sprint");
            inc -= 0.2f;
            yield return new WaitForSeconds(1/Use_Sprint_Speed);
        }
        FPS.movementSettings.Can_Sprint= false;
        StartCoroutine(Regain_Sprint());
    }

}
