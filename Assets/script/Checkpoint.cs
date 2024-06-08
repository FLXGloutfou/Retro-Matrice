using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Check On", true);
            Hero player = other.gameObject.GetComponent<Hero>();
            player.SetRespawnPoint(transform.position); 
        }
    }
}