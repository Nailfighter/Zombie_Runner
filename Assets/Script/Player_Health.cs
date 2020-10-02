using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField] int Health_P;

    public void enemy_hit(int enemy_damage)
    {
        Health_P -= enemy_damage;
        check_if_dead();
    }
    void check_if_dead()
    {
        if (Health_P <= 0)
        {
            print("You ded");
        }
    }
}
