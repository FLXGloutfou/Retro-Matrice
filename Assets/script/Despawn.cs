using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float destroyDelay = 0f;

    private void Update()
    {
        Destroy(gameObject, destroyDelay);
    }
}