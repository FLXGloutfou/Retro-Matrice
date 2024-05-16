using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // R�f�rence au joueur que la cam�ra va suivre

    void LateUpdate()
    {
        if (target != null)
        {
            // D�placer la cam�ra pour qu'elle soit centr�e sur le joueur
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}