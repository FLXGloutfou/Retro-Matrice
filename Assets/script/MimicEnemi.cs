using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicEnemi : MonoBehaviour
{

    public Sprite eatMimicSprite ;
    public float damageAmount;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = eatMimicSprite;
            collision.gameObject.GetComponent<Hero>().TakeDamage(damageAmount);
        }
    }
}
