using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    AudioSource AudioSource;
    [SerializeField] AudioClip Weapon_Sound;
    [SerializeField] AudioClip Out_Of_ammo;
    [SerializeField] GameObject Impact_Particle_Sys;
    [SerializeField] ParticleSystem Muzzle_Flash;
    [SerializeField] int bullet_damage=20;
    [SerializeField] float Gun_Range=100f;
    [SerializeField] Ammo Ammo_Info;
    public Ammo_Types Ammo_Type;
    [SerializeField] bool Auto=false;
    [SerializeField] float Shoot_Delay = 1f;

    bool is_shoot=false;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        //prevent player exploit
        is_shoot = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Gun_Range);
    }
    private void Update()
    {
        if (Auto)
        {
            if (Input.GetButton("Fire1") && Ammo_Info.Ammo_Left(Ammo_Type) > 0 && !is_shoot)
            {
                StartCoroutine(shoot());
            }
        }
        else if (Input.GetButtonDown("Fire1") && Ammo_Info.Ammo_Left(Ammo_Type) > 0 && !is_shoot)
        {
            StartCoroutine(shoot());
        }
        else if (Input.GetButtonDown("Fire1") && Ammo_Info.Ammo_Left(Ammo_Type) <= 0)
        {
            AudioSource.PlayOneShot(Out_Of_ammo);
        }

    }

    IEnumerator shoot()
    {
 
        is_shoot = true;
        Muzzle_Flash.Play();
        AudioSource.PlayOneShot(Weapon_Sound);
        RaycastHit hit_object;
        Transform camera = Camera.main.transform;
        if(Physics.Raycast(camera.position, camera.forward, out hit_object, Gun_Range))
        {
            Start_RayTracing(hit_object);
        }
        Ammo_Info.Reduce_Ammo(Ammo_Type);
        yield return new WaitForSeconds(Shoot_Delay);
        is_shoot = false;

    }

    private void Start_RayTracing(RaycastHit hit_object)
    {
        impact_surafce(hit_object);
        if (hit_object.transform.GetComponent<Enemy_Bio>())
        {
            hit_object.transform.gameObject.GetComponent<Enemy_Bio>().bullet_hit(bullet_damage);
            Provoke_Shoot(hit_object);
        }
    }

    private static void Provoke_Shoot(RaycastHit hit_object)
    {
        if (!hit_object.transform.gameObject.GetComponent<Enemy_AI>().is_provoked)
        {
            hit_object.transform.gameObject.GetComponent<Enemy_AI>().Following_player();
        }
    }

    void impact_surafce(RaycastHit hit_object)
    {
        GameObject Impact_Particle = Instantiate(Impact_Particle_Sys, hit_object.point, Quaternion.LookRotation(hit_object.normal));
        Destroy(Impact_Particle, 1f);
    }
  
}
