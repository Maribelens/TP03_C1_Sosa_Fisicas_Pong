using UnityEngine;
using Random = UnityEngine.Random;
public class InputMovement : MonoBehaviour
{
    [Header("Keys")]
    public KeyCode KeyUp;
    public KeyCode KeyDown;
    public KeyCode KeyLeft;
    public KeyCode KeyRight;

    [Header("Paddles")]
    [SerializeField] GameObject paddle;
    [SerializeField] Transform initia1PosPlayer;

    [Header("Movement")]
    public float speed = 1f;
    [SerializeField] Rigidbody2D paddleRb2D;
    [SerializeField] private SpriteRenderer spriteRen;
    [SerializeField] private GameManager gmManager;

    private void Awake()
    {
        if (paddleRb2D == null)
        {
            paddleRb2D = GetComponent<Rigidbody2D>();
        }
        if (spriteRen == null)
        {
            spriteRen = GetComponent<SpriteRenderer>();
        }
    }

    private void Start()
    {
        ResetAndLaunch();
    }

    private void FixedUpdate()
    {
        MovePaddle();
    }

    public void ResetAndLaunch()
    {
        paddle.transform.position = initia1PosPlayer.position;

    }

    private void MovePaddle()
    {
        Vector2 move = Vector2.zero;

        if (Input.GetKey(KeyUp))
        {
            move += Vector2.up * speed;
        }
        else if (Input.GetKey(KeyDown))
        {
            move += Vector2.down * speed;
        }

        if (Input.GetKey(KeyLeft))
        {
            move += Vector2.left * speed;
        }
        else if (Input.GetKey(KeyRight))
        {
            move += Vector2.right * speed;
        }

        if (move != Vector2.zero)
        {
            paddleRb2D.AddForce(move);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Goal"))
        {
            spriteRen.color = Color.black;
        }
        if (collision.collider.CompareTag("Ball"))
        {
            spriteRen.color = Random.ColorHSV();
        }
    }
}

//[Header("Apariencia")]
//[SerializeField] public SpriteRenderer spriteRen;
//Vector3 initialScale;
//private Color paddleColor;