using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // Référence vers le héros
    public float baseFollowSpeed = 2f; // Vitesse de suivi de base
    public float Offset = -1f;

    private Vector3 lastTargetPosition;
    private Vector3 targetVelocity;

    private void Start()
    {
        lastTargetPosition = target.position;
    }

    private void Update()
    {

        targetVelocity = (target.position - lastTargetPosition) / Time.deltaTime;
        lastTargetPosition = target.position;

        float adaptiveFollowSpeed = baseFollowSpeed + targetVelocity.magnitude;

        Vector3 newPos = new Vector3(target.position.x, target.position.y + Offset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, adaptiveFollowSpeed * Time.deltaTime);
    }
}
