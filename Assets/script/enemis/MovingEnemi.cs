
using UnityEngine;

public class MovingEnemi : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    private Transform target;
    private int desPoint = 0;

    public int damageAmount = 1;
    public float repelForce = 5f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        target = waypoints[0];
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            desPoint = (desPoint + 1) % waypoints.Length;
            target = waypoints[desPoint];

            //spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<Hero>().TakeDamage(damageAmount);
        }
    }
}
