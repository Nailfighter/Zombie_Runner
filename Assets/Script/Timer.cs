using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text Time_Text;
    float Clock = 0f;
    float To_Clock=0f;
    void Update()
    {
        To_Clock =To_Clock+Time.deltaTime;
        Clock = Mathf.RoundToInt(To_Clock);
        Time_Text.text = (Clock-(Clock%60)+":"+(Clock%60)).ToString();
    }
}
