using UnityEngine;

public class move : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public float forceSaut = 10f;
    public Transform solCheckPosition;

    private bool auSol = false;
    private bool peutSauter = true;
    private int nombreSautsRestants = 2;

    private Rigidbody2D rb;
    private Animator animator;
    public SpriteRenderer spriterenderer;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Déplacement horizontal
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(deplacementHorizontal * vitesseDeplacement, rb.velocity.y);

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

        Flip(rb.velocity.x);
        float speed = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", speed);
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriterenderer.flipX = false;
        }
        else if (_velocity < 0.1f)
        {
            spriterenderer.flipX = true;
        }
    }


}