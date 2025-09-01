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

    //float paddleY = collision.transform.position.y;
    //float contactY = ballRb.position.y;
    //float halfHeight = collision.collider.bounds.size.y * 0.5f;

//direction.x = -direction.x;
//float difference = transform.position.y - collision.transform.position.y;
//direction.y = difference;
//direction.Normalize();
//    //direction.y = -direction.y;
//    //rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + 0.2f);

//if (collision.otherCollider.CompareTag("Goal"))
//{
//    Debug.Log("se colisiono!");
//    transform.position = Vector3.zero;
//    rb.velocity = Vector2.zero;
//    //direction.x = -direction.x;
//    rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + 0.2f);
//}



//float xSpeed;
//float ySpeed;

//transform.Translate(direction * initialSpeed * Time.deltaTime);

////if (Random.Range(0,2) == 0)
//if (transform.position.y > 4f || transform.position.y < -4f)
//{
//    //xSpeed = 1;
//    direction.y = -direction.y;
//}
//else
//{
//    //xSpeed = -1;
//}

//if (transform.position.x > 7f || transform.position.x < -7f)
////(Random.Range(0, 2) == 0)
//{
//    //ySpeed = 1;
//    direction.x = -direction.x;
//}
//else
//{
//    //ySpeed = -1;
//}


//float x;
//float y;
//if (Random.value < 0.5f)
//{
//    x = -1f * speed * Time.deltaTime;
//}
//else
//{
//    x = 1f * speed * Time.deltaTime;
//}
//y = Random.Range(-0.5f, 0.5f);
//Vector2 direction = new Vector2(x, y);

//rb.velocity = direction * speed * Time.deltaTime;



//private void OnCollisionEnter(Collision other)
//{
//    if(other.collider.CompareTag("Goal"))
//    {
//        transform.position = Vector3.zero;
//        Launch();
//    }
//}



