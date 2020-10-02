using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_AI : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent enemy_nav;
    [SerializeField] float target_range;
    public bool is_provoked=false;
    [SerializeField] float Rot_Time=10f;

    float distance_to_player = Mathf.Infinity;
    public Animator Enemy_Animator;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(player.position, transform.position);
        Gizmos.DrawWireSphere(transform.position, target_range);
    }
    private void Start()
    {
        Enemy_Animator = GetComponent<Animator>();
        is_provoked = false;
        enemy_nav = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        check_if_provoked();
        if (is_provoked)
        {
            Engage();
        }

    }

    private void check_if_provoked()
    {
        distance_to_player = Vector3.Distance(player.position, transform.position);
        if (distance_to_player <= target_range)
        {
            is_provoked = true;
        }

    }

    private void Engage()
    {
        Face_player();
        if (distance_to_player >= enemy_nav.stoppingDistance)
        {
            Following_player();
        }
        else
        {
            Combat();
        }
    }

    public void Following_player()
    {
        Enemy_Animator.SetTrigger("Move");
        Enemy_Animator.SetBool("Attack", false);
        enemy_nav.SetDestination(player.position);
    }
    void Combat()
    {
        Enemy_Animator.SetBool("Attack",true);
    }
    void Face_player()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion To_look = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, To_look, Rot_Time * Time.deltaTime);
    }
}

