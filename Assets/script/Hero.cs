using UnityEngine;
using System.Collections;
using Rewired;

public class Hero : MonoBehaviour
{
    public int playerId = 0; // Le joueur Rewired dont nous voulons contr�ler ce GameObject
    private Player player; // Le Player Rewired associ� � ce joueur

    public float moveSpeed = 5f; // Vitesse de d�placement

    private void Awake()
    {
        // Obtenez le Player associ� � ce joueur
        player = ReInput.players.GetPlayer(playerId);
    }

    private void Update()
    {
        // D�placement horizontal

        // D�placement du joueur
        Vector3 moveDirection = new Vector3(player.GetAxis("MoveHorizontal"), 0f, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
