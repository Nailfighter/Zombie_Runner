//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.PlayerLoop;
//using UnityEngine.UI;
//using UnityStandardAssets.Characters.FirstPerson;
//using UnityStandardAssets.Utility;

//public class Sprint_Limit : MonoBehaviour
//{
//    float inc = 10f;
//    public  float Use_Sprint_Speed = 1f;
//    public float Recover_Sprint_Speed = 1f;
//    RigidbodyFirstPersonController FPS;
//    int Bar_Value = 100;
//    Slider Sprint_Slider;
//    public bool is_sprinting = false;
//    private void Start()
//    {
//        inc = 1;
//        FPS = FindObjectOfType<RigidbodyFirstPersonController>();
//        Sprint_Slider = GetComponent<Slider>();
//    }
//    private void Update()
//    {
//        Bar_Value = Mathf.RoundToInt(Mathf.Lerp(0, 100, inc));
//        Sprint_Slider.value = Bar_Value;
//        sprint();
//    }
//    void sprint()
//    {
//        if (Input.GetKey(KeyCode.LeftShift))
//        {
//            if (!is_sprinting && FPS.movementSettings.Can_Sprint)
//            {
//                StopAllCoroutines();
//                StartCoroutine(Use_Sprint());
//                is_sprinting = true;
//            }

//        }
//        else
//        {
//            if (is_sprinting)
//            {
//                StopAllCoroutines();
//                StartCoroutine(Regain_Sprint());
//                is_sprinting = false;
//            }
//        }
//    }
//    IEnumerator Regain_Sprint ()
//    {
//        while (inc<1)
//        {
//            inc += 0.1f;
//            yield return new WaitForSeconds(1/Recover_Sprint_Speed);
//        }
//        print("Full recover");
//        FPS.movementSettings.Can_Sprint = true;

//    }
//    public IEnumerator Use_Sprint()
//    {

//        while (inc > 0)
//        {
//            print("using sprint");
//            inc -= 0.2f;
//            yield return new WaitForSeconds(1/Use_Sprint_Speed);
//        }
//        FPS.movementSettings.Can_Sprint= false;
//        StartCoroutine(Regain_Sprint());
//    }

//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Utility;

public class Sprint_Limit : MonoBehaviour
{
    public float inc = 1;
    public float Use_Sprint_Speed = 1f;
    public float Recover_Sprint_Speed = 1f;
    RigidbodyFirstPersonController FPS;
    public float Bar_Value = 100;
    Slider Sprint_Slider;
    public bool Can_Sprint = true;
    private void Start()
    {
        FPS = FindObjectOfType<RigidbodyFirstPersonController>();
        Sprint_Slider = GetComponent<Slider>();
    }
    private void Update()
    {
        sprint();
        Sprint_Slider.value = Bar_Value;
    }
    void sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Can_Sprint)
        {
            Use_Sprint();
        }
        else 
        {
            Regain_Sprint();
        }
    }
    void Regain_Sprint()
    {
        if (inc < 1)
        {
            inc += Time.deltaTime * Recover_Sprint_Speed/10;
            Bar_Value = Mathf.Lerp(0, 100, inc);

        }
        else
        {
            Can_Sprint = true;
            FPS.movementSettings.Can_Sprint = Can_Sprint;
            inc = 1;
        }

    }
    public void Use_Sprint()
    {
        if (inc > 0)
        {
            inc -= Time.deltaTime * Use_Sprint_Speed / 10;
            Bar_Value = Mathf.Lerp(0, 100, inc);
        }
        else
        {
            inc = 0;
            Can_Sprint = false;
            FPS.movementSettings.Can_Sprint = Can_Sprint;
            Regain_Sprint();
        }
    }

}
