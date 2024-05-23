using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropingturret : MonoBehaviour
{
    private float Timer;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 2)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
        {
            int enemisLayer = LayerMask.NameToLayer("Enemis");

            if (collision.gameObject.layer == enemisLayer)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
}
