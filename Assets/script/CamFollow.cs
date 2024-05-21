using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float UpoffsetDistance = -2f;
    public float RightoffsetDistance = 4f;

    void LateUpdate()
    {
        if (target != null)
        {
            // D�placer la cam�ra pour qu'elle soit centr�e sur le joueur
            transform.position = new Vector3(target.position.x + RightoffsetDistance, target.position.y - UpoffsetDistance, transform.position.z);
        }
    }
}