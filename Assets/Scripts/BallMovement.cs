using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private GameManager gmManager;
    [SerializeField] float speed = 2f;
    Rigidbody2D rb;
    float directionX;
    float directionY;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        ResetAndLaunch();
    }

    public void ResetAndLaunch()
    {
        transform.position = Vector3.zero;
        if (Random.value < 0.5f)
        {
            directionX = -1f;
        }
        else
        {
            directionX = 1f;
        }
        directionY = Random.Range(-0.5f, 0.5f);

        Vector2 direction;
        direction = new Vector2(directionX, directionY).normalized;

        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            InvertXDirection(collision);
            Debug.Log("se colisiono!");
            Debug.Log("velocidad actual: " + speed);
        }

        else if (collision.collider.CompareTag("Wall"))
        {
            rb.velocity = rb.velocity.normalized * Mathf.Max(rb.velocity.magnitude, 0.01f);
        }

    }
    void InvertXDirection(Collision2D collision)
    {
        Rigidbody2D paddleRb = collision.collider.attachedRigidbody;
        Vector2 direction = new Vector2(Mathf.Sign(-rb.velocity.x), directionX).normalized;
        speed += 0.3f;
        rb.velocity = direction * speed;
    }
}



