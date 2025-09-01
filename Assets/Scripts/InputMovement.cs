using UnityEngine;
public class InputMovement : MonoBehaviour
{
    [Header("Keys")]
    public KeyCode KeyUp;
    public KeyCode KeyDown;

    [Header("Movement")]
    [SerializeField] private float minY = -4.2f;
    [SerializeField] private float maxY = 4.2f;
    public float speed = 7f;

    [Header("Apariencia")]
    [SerializeField] public SpriteRenderer spriteRen;
    Rigidbody2D rb;
    Vector3 initialScale;

    //private Color paddleColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        initialScale = transform.localScale;
        if(spriteRen == null) spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePaddle();
    }

    private void MovePaddle()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey(KeyUp))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyDown))
        {
            pos.y -= speed * Time.deltaTime;
        }

        transform.position = pos;
        //paddleRb.MovePosition(pos);
    }
}
