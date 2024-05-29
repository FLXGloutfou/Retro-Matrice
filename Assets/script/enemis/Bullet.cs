using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;

    public float Vitesse;
    private float Timer;
    public float damage;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * Vitesse;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Hero>().TakeDamage(damage);

            Destroy(gameObject);
        }
        int solidLayer = LayerMask.NameToLayer("Solid");

        if (collision.gameObject.layer == solidLayer)
        {
            Destroy(gameObject);
        }
    }

}
