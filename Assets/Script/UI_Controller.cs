using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] AudioMixer volume;
    public Game_Data Data;
    private void Start()
    {
        Data.Sensitivity = 2f;
        Data.Difficulty = Game_Data.mode.Beginner;
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Next_level()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void volume_changer(float level)
    {
        volume.SetFloat("Volume", level);
    }

    public void Sensitivity_Changer(float level)
    {
        Data.Sensitivity = level;
    }
        public void set_difficulty(int Index)
    {
        switch(Index)
        {
            case 0:
                Data.Difficulty = Game_Data.mode.Beginner;
                break;
            case 1:
                Data.Difficulty = Game_Data.mode.Amateur;
                break;
            case 2:
                Data.Difficulty = Game_Data.mode.Nightmare;
                break;
        }
    }
}
