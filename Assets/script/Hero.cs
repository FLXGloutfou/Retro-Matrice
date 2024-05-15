using UnityEngine;
using System.Collections;
using Rewired;

public class Hero : MonoBehaviour
{
    public int playerId = 0; // Le joueur Rewired dont nous voulons contrôler ce GameObject
    private Player player; // Le Player Rewired associé à ce joueur

    public float moveSpeed = 5f; // Vitesse de déplacement

    private void Awake()
    {
        // Obtenez le Player associé à ce joueur
        player = ReInput.players.GetPlayer(playerId);
    }

    private void Update()
    {
        // Déplacement horizontal

        // Déplacement du joueur
        Vector3 moveDirection = new Vector3(player.GetAxis("MoveHorizontal"), 0f, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
