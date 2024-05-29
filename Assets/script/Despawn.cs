using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public bool Isactive;
    public float destroyDelay = 0f;

    void Start()
    {
        Isactive = true;
    }
    private void Update()
    {
        Destroy(gameObject, destroyDelay);
    }

    public void SetActiveTurret()
    {
        Isactive = true;
    }
    public void SetDesActiveTurret()
    {
        Isactive = false;
    }

}