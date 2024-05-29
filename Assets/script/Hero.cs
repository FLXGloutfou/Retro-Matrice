using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public float forceSaut = 10f;
    public Transform solCheckPosition;
    public GameObject[] prefabsToInvoke; 
    public Vector2[] offsetDistances;
    public int nombreSautsRestants = 2;
    public int currentPrefabIndex = 0;
    public int TurretLoad = 0;
    public MonoBehaviour scriptOnPrefab;
    public float newOpacity = 1f;
    private GameObject currentPreShowFab;
    public delegate void TurretLoadChangedEventHandler(int newTurretLoad);
    public static event TurretLoadChangedEventHandler OnTurretLoadChanged;
    public GameObject PauseWindow;
    bool isPaused;

    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public delegate void HealthChangedEventHandler(float newHealth);
    public static event HealthChangedEventHandler OnHealthChanged;
    private Vector3 respawnpoint;


    private bool auSol = false;
    private bool peutSauter = true;
    private Rigidbody2D rb;
    private bool faceRight = true;
    private Vector2 moveInput;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnpoint = transform.position;
        isPaused = false;

    }

    void Update()
    {
        if (!isPaused)
        {
            Move();
            PreShowPrefab();

            // V�rification du sol
            auSol = Physics2D.Raycast(solCheckPosition.position, Vector2.down, 0.2f);

            if (auSol)
            {
                nombreSautsRestants = 2;
                peutSauter = true;
            }
        }
        
    }

    //==================================== LES INPUT====================================//

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && (auSol || (peutSauter && nombreSautsRestants > 0)))
        {
            rb.velocity = new Vector2(rb.velocity.x, forceSaut);

            if (!auSol)
            {
                nombreSautsRestants--;
                peutSauter = false;
            }
        }
    }

    public void OnInvoqueTurret(InputAction.CallbackContext context)
    {
        if (context.performed && prefabsToInvoke.Length > 0 && TurretLoad > 0)
        {
            Vector2 offset = offsetDistances.Length > currentPrefabIndex ? offsetDistances[currentPrefabIndex] : Vector2.right;
            Vector2 spawnPosition = (Vector2)transform.position + (faceRight ? new Vector2(offset.x, offset.y) : new Vector2(-offset.x, offset.y));
            Instantiate(prefabsToInvoke[currentPrefabIndex], spawnPosition, Quaternion.identity);
            TurretLoad -= 1;
            OnTurretLoadChanged?.Invoke(TurretLoad);
        }
    }

    public void OnNextPrefab(InputAction.CallbackContext context)
    {
        if (context.performed && prefabsToInvoke.Length > 0)
        {
            currentPrefabIndex = (currentPrefabIndex + 1) % prefabsToInvoke.Length;
        }
            
    }

    public void OnPrevPrefab(InputAction.CallbackContext context)
    {
        if (context.performed && prefabsToInvoke.Length > 0)
        {
            currentPrefabIndex = (currentPrefabIndex - 1 + prefabsToInvoke.Length) % prefabsToInvoke.Length;
        }
    }

    public void Restart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                PauseWindow.SetActive(true);                
            }
            else
            {
                Time.timeScale = 1;
                PauseWindow.SetActive(false);
            }
        }
    }

    //==================================== LE CODE====================================//
    void Move()
    {
        float deplacementHorizontal = moveInput.x;
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

    public void TurretLoadCount(int value)
    {
        TurretLoad += value;
        OnTurretLoadChanged?.Invoke(TurretLoad);
    }

    void PreShowPrefab()
    {
        Vector2 offset = offsetDistances.Length > currentPrefabIndex ? offsetDistances[currentPrefabIndex] : Vector2.right;
        Vector2 spawnPosition = (Vector2)transform.position + (faceRight ? new Vector2(offset.x, offset.y) : new Vector2(-offset.x, offset.y));

        Destroy(currentPreShowFab);
        currentPreShowFab = Instantiate(prefabsToInvoke[currentPrefabIndex], spawnPosition, Quaternion.identity);

        if (currentPreShowFab)
        {
            SpriteRenderer spriteRenderer = currentPreShowFab.GetComponent<SpriteRenderer>();
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = newOpacity;
            spriteRenderer.color = spriteColor;

            Collider2D colliderToDisable = currentPreShowFab.GetComponent<Collider2D>();
            colliderToDisable.enabled = false;
            scriptOnPrefab = currentPreShowFab.GetComponent<MonoBehaviour>();
            scriptOnPrefab.enabled = false;
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
