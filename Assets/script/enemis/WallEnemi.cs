using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnemi : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private GameObject player;
    private GameObject spawnedWall;
    private bool wallSpawned = false;

    public GameObject mur;
    public float distanceFromEnemy = 1f;
    public float verticalOffset;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 6 && !wallSpawned)
        {

            Wall();
            animator.SetBool("IsOn", true);
        }
        else if (distance >= 6 && wallSpawned)
        {

            DestroySpawnedWall();
            animator.SetBool("IsOn", false);
        }

        if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false; // Flip horizontalement si le joueur est à droite
        }
        else
        {
            spriteRenderer.flipX = true; // Ne pas flip si le joueur est à gauche
        }
    }

    void Wall()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.Normalize();
        Vector3 spawnPosition = transform.position + directionToPlayer * distanceFromEnemy;
        spawnPosition.y = transform.position.y + verticalOffset;
        spawnedWall = Instantiate(mur, spawnPosition, Quaternion.identity, this.transform);
        wallSpawned = true;
    }



    void DestroySpawnedWall()
    {
        Destroy(spawnedWall);
        wallSpawned = false;
    }

}
