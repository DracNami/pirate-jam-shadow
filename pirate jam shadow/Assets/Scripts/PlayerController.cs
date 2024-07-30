using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    Vector2 input;
    public float moveSpeed = 5;

    [field: Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer playerSprite;
    public Animator ani;

    public bool inResonance = false;
    public bool isAttacking = false;
    public bool canMove = false;
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //action = GetComponent<ActionController>();
    }

    private void Update()
    {
        GetInput();
        Attack();
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking && !inResonance)
        {
            isAttacking = true;
        }
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
        if (canMove)
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
}
