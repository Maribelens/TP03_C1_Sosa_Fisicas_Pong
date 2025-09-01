using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float initialSpeed = 5f;
    [SerializeField] float speedIncreaseOnHit = 0.25f;
    [SerializeField] float maxSpeed = 17f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Start()
    {
        ResetAndLaunch();
    }

    public void ResetAndLaunch()
    {
        transform.position = Vector3.zero;
        float x;
        if (Random.value < 0.5f)
        {
            x = -1f;
        }
        else
        {
            x = 1f;
        }
        float y = Random.Range(-0.5f, 0.5f);

        Vector2 direction;
        direction = new Vector2(x, y).normalized;
        rb.velocity = direction * initialSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            Rigidbody2D paddleRb = collision.collider.attachedRigidbody;
            float paddleY = collision.collider.transform.position.y;
            float contactY = collision.GetContact(0).point.y;
            float paddleHeight = collision.collider.bounds.size.y;

            float relative = (contactY - paddleY) / (paddleHeight / 2f); // -1 .. 1
            Vector2 newDirection = new Vector2(Mathf.Sign(-rb.velocity.x), relative).normalized;

            float newSpeed = Mathf.Min(rb.velocity.magnitude + speedIncreaseOnHit, maxSpeed);
            rb.velocity = newDirection * newSpeed;

            Debug.Log("se colisiono!");
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            rb.velocity = rb.velocity.normalized * Mathf.Max(rb.velocity.magnitude, 0.01f);
        }

    }
}



