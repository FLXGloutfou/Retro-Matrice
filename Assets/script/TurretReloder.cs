using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretReloder : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Hero TurretCount = other.GetComponent<Hero>();
            if (TurretCount != null)
            {
                TurretCount.TurretLoadCount(value);
            }
            Destroy(gameObject);
        }
    }
}
