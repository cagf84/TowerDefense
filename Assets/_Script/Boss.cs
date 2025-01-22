using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 100;

    public Animator Anim;

    private void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        Anim = GetComponent<Animator>();
        Anim.SetBool("IsMoving", true);
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            Anim.SetBool("IsMoving", false);
            Anim.SetTrigger("OnObjetiveReached");
        }
    }

    public void Danar()
    {
        objetivo?.GetComponent<Objetivo>().RecibirDano(25);
    }

    public void RecibirDano(int dano = 5)
    {

    }
}
