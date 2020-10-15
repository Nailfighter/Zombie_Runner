using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Game_Data : ScriptableObject
{
   public bool initial_reset_done = false;
   public float Sensitivity = 2f;
   public enum mode { Beginner, Amateur, Nightmare }
   public mode Difficulty=mode.Beginner;
}

