using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnemi : MonoBehaviour
{
    private GameObject player;
    private GameObject spawnedWall;
    private bool wallSpawned = false;

    public GameObject mur;
    public float distanceFromEnemy = 1f;
    public float verticalOffset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

   
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 6 && !wallSpawned)
        {
            Wall();
        }
        else if (distance >= 6 && wallSpawned)
        {
            DestroySpawnedWall();
        }
    }

    void Wall()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.Normalize();
        Vector3 spawnPosition = transform.position + directionToPlayer * distanceFromEnemy + Vector3.up * verticalOffset;
        spawnedWall = Instantiate(mur, spawnPosition, Quaternion.identity, this.transform);
        wallSpawned = true;
    }



    void DestroySpawnedWall()
    {
        Destroy(spawnedWall);
        wallSpawned = false;
    }
}
