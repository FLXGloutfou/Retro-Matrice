using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject Message;

    private void Start()
    {
        Message.SetActive(false);
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Message.SetActive(true);
        }
    }
}
