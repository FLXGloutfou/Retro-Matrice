using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPrefabDoor : MonoBehaviour
{
    public Despawn despawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
