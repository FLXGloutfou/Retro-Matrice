using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicEnemi : MonoBehaviour
{

    public float damageAmount;

    private Animator animator;
    private Hero heroScript;
    void Start()
    {
        animator = GetComponent<Animator>();
        heroScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Eat On", true);
            heroScript.SetPeutBouger(false);
            Invoke("Eat", 1f);  
        }

        
    }

    void Eat()
    {
        animator.SetBool("Eat On", false);
        heroScript.SetPeutBouger(true);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Hero>().TakeDamage(damageAmount);
    }
}
