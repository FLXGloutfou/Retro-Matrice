using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public float forceSaut = 10f;
    public Transform solCheckPosition;
    public GameObject[] prefabsToInvoke; 
    public float offsetDistance = 1f;
    public int nombreSautsRestants = 2;
    public int currentPrefabIndex = 0;
    public int TurretLoad = 0;
    public delegate void TurretLoadChangedEventHandler(int newTurretLoad);
    public static event TurretLoadChangedEventHandler OnTurretLoadChanged;

    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public delegate void HealthChangedEventHandler(float newHealth);
    public static event HealthChangedEventHandler OnHealthChanged;
    private Vector3 respawnpoint;


    private bool auSol = false;
    private bool peutSauter = true;
    private Rigidbody2D rb;
    private bool faceRight = true;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnpoint = transform.position;
    }

    void Update()
    {
        InvoqueTurret();
        ChangePrefab();
        Move();

        // V�rification du sol
        auSol = Physics2D.Raycast(solCheckPosition.position, Vector2.down, 0.2f);

        
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

        //===SAUT===
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

    public void TurretLoadCount(int value)
    {
        TurretLoad += value;
        OnTurretLoadChanged?.Invoke(TurretLoad);
    }

    void InvoqueTurret()
    {
        if (Input.GetButtonDown("Create") && prefabsToInvoke.Length > 0 && TurretLoad > 0)
        {
            // Calcule la position devant le joueur
            Vector2 spawnPosition = transform.position;
            spawnPosition += faceRight ? Vector2.right * offsetDistance : Vector2.left * offsetDistance;
            Instantiate(prefabsToInvoke[currentPrefabIndex], spawnPosition, Quaternion.identity);
            TurretLoad -= 1;
            OnTurretLoadChanged?.Invoke(TurretLoad);
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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }

    void die()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);
        transform.position = respawnpoint;
    }
    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnpoint = newRespawnPoint;
    }
}
