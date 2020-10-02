using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weapon_Zoomer : MonoBehaviour
{
    RigidbodyFirstPersonController FPSController;
    [SerializeField] float Zoomed_Mouse_Sensitivity=1f;
    Camera Camera_M;
    [SerializeField] int Zoom_Scroll_Sensitivity=5;
    [SerializeField] int Min_Zoom = 20;
    [SerializeField] int Max_Zoom = 60;
    [SerializeField] int Normal_Zoom = 60;
    int In_Out_Scroll_Value;
    float Zoom_X, Zoom_Y;
    float Org_X, Org_Y;
    bool Is_Zoom = false;

    private void OnDisable()
    {
        Zoomer(Normal_Zoom);
    }

    private void Start()
    {
        FPSController = GetComponentInParent<RigidbodyFirstPersonController>();
        Camera_M = Camera.main;
        Mouse_sensitivity_Value();
        In_Out_Scroll_Value = Min_Zoom;
    }
    private void FixedUpdate()
    {
        To_Scope_In_Or_Out();
    }
    void To_Scope_In_Or_Out()
    {
        if (Input.GetMouseButton(1))
        {
            scope_slider();
            if (Is_Zoom) { return; }
            Is_Zoom = true;
            Zoomer(In_Out_Scroll_Value);
            Mouse_sensitivity_Changer();

        }
        else
        {
            if (!Is_Zoom) { return; }
            Is_Zoom = false;
            Zoomer(Normal_Zoom);
            Mouse_sensitivity_Changer();
        }
    }
    void scope_slider()
    {
        float Raw_Scroll_Value = Input.GetAxis("Mouse ScrollWheel");
        if (Raw_Scroll_Value > 0f)
        {
            In_Out_Scroll_Value=Mathf.Clamp(In_Out_Scroll_Value + Zoom_Scroll_Sensitivity,Min_Zoom,Max_Zoom);
            Zoomer(In_Out_Scroll_Value);
        }
        if (Raw_Scroll_Value < 0f)
        {
            In_Out_Scroll_Value= Mathf.Clamp(In_Out_Scroll_Value - Zoom_Scroll_Sensitivity, Min_Zoom, Max_Zoom);
            Zoomer(In_Out_Scroll_Value);
        }

    }

    private void Mouse_sensitivity_Changer()
    {
        if (Is_Zoom)
        {
            FPSController.mouseLook.XSensitivity = Zoom_X;
            FPSController.mouseLook.YSensitivity = Zoom_Y;
        }
        else
        {
            FPSController.mouseLook.XSensitivity = Org_X;
            FPSController.mouseLook.YSensitivity = Org_Y;
        }
    }
    void Mouse_sensitivity_Value()
    {
        Org_X = FPSController.mouseLook.XSensitivity;
        Org_Y = FPSController.mouseLook.YSensitivity;
        Zoom_X = FPSController.mouseLook.XSensitivity * Zoomed_Mouse_Sensitivity;
        Zoom_Y = FPSController.mouseLook.XSensitivity * Zoomed_Mouse_Sensitivity;
    }
    void Zoomer(int Scope_FOW)
    {
        Camera_M.fieldOfView = Scope_FOW;
    }
}
