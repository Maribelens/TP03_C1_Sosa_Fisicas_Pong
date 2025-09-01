using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 7f;
    //public float rotation = 10f;
    //public SpriteRenderer spriteRen;

    [Header("Keys")]
    public KeyCode KeyUp;
    public KeyCode KeyDown;
    public KeyCode KeyLeft;
    public KeyCode KeyRight;

    //private void Awake()
    //{
    //    if (spriteRen == null)
    //    {
    //        spriteRen = GetComponent<SpriteRenderer>();
    //    }
    //}

    // Update is called once per frame
    void Update()
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
        if (Input.GetKey(KeyLeft))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyRight))
        {
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
