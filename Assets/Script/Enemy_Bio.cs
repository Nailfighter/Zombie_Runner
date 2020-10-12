using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;

namespace Assets.Script
{
    public class Enemy_Bio : MonoBehaviour
    {
        [SerializeField] int Health_E = 100;
        [SerializeField] int Damage_Dealt = 20;
        bool is_dead = false;
        void check_dead()
        {
            if (Health_E <= 0 && !is_dead)
            {
                is_dead = true;
                Zombie_Dead();
            }
        }

        private void Zombie_Dead()
        {
            gameObject.tag = "Dead_Enemy";
            GetComponent<Enemy_AI>().Enemy_Animator.SetTrigger("Is_Dead");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Enemy_AI>().enabled = false;
            enabled = false;
        }

        public void bullet_hit(int gun_damage)
        {
            Health_E -= gun_damage;
            check_dead();
        }

        void Anim_Event_Kill_Player()
        {
            FindObjectOfType<Player_Health>().enemy_hit(Damage_Dealt);
            FindObjectOfType<Player_Related_Audio>().Hit_Sound();
        }
       
    }
}




