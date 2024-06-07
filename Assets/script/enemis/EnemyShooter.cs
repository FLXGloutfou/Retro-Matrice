using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpos;

    public Sprite spriteNormal;
    public Sprite spriteShooting;
    private SpriteRenderer spriteRenderer;

    private bool isShooting = false;
    private bool hasShot = false;


    private float timer ;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {     
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
                isShooting = true;
                hasShot = false;
            }
        }       
    }
 

    void shoot()
    {
        spriteRenderer.sprite = spriteShooting;
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
        hasShot = true;
        Invoke("ResetSprite", 0.5f);
    }

    void ResetSprite()
    {
        spriteRenderer.sprite = spriteNormal;
        isShooting = false;
    }

}
