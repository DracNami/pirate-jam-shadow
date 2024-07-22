using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 input;
    public float moveSpeed = 5;

    [field: Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer playerSprite;

    void Start()
    {
        
    }

    private void Update()
    {
        GetInput();
    }
    void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void Move()
    {
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);

        if (input.x < 0)
        {
            playerSprite.flipX = true;
        }
        else if (input.x > 0)
        {
            playerSprite.flipX = false;
        }
    }
}
