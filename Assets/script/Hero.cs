using UnityEngine;

public class move : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public float forceSaut = 10f;
    public Transform solCheckPosition;
    public GameObject[] prefabsToInvoke; 
    public float offsetDistance = 1f; 


    private bool auSol = false;
    private bool peutSauter = true;
    private int nombreSautsRestants = 2;
    private Rigidbody2D rb;
    private bool faceRight = true; 
    private int currentPrefabIndex = 0; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InvoqueTurret();
        ChangePrefab();
        Move();

        // Vérification du sol
        auSol = Physics2D.Raycast(solCheckPosition.position, Vector2.down, 0.2f);

        // Saut
        if (auSol)
        {
            nombreSautsRestants = 2;
            peutSauter = true;
        }

        if (Input.GetButtonDown("Jump") && (auSol || (peutSauter && nombreSautsRestants > 0)))
        {
            rb.velocity = new Vector2(rb.velocity.x, forceSaut);

            if (!auSol)
            {
                nombreSautsRestants--;
                peutSauter = false;
            }
        }
    }

    void Move()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(deplacementHorizontal * vitesseDeplacement, rb.velocity.y);

        if (deplacementHorizontal > 0 && !faceRight)
        {
            Flip();
        }
        else if (deplacementHorizontal < 0 && faceRight)
        {
            Flip();
        }
    }

    void InvoqueTurret()
    {
        if (Input.GetButtonDown("Create") && prefabsToInvoke.Length > 0)
        {
            // Calcule la position devant le joueur
            Vector2 spawnPosition = transform.position;
            spawnPosition += faceRight ? Vector2.right * offsetDistance : Vector2.left * offsetDistance;
            Instantiate(prefabsToInvoke[currentPrefabIndex], spawnPosition, Quaternion.identity);
        }
    }

    void ChangePrefab()
    {
        if (Input.GetButtonDown("nextPrefab") && prefabsToInvoke.Length > 0)
        {
            currentPrefabIndex = (currentPrefabIndex + 1) % prefabsToInvoke.Length;
        }

        if (Input.GetButtonDown("prevPrefab") && prefabsToInvoke.Length > 0)
        {
            currentPrefabIndex = (currentPrefabIndex - 1 + prefabsToInvoke.Length) % prefabsToInvoke.Length;
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
