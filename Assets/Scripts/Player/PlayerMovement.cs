using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private LayerMask groundLayer;
    private float horizontalInput;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    [Header ("SFX")]
    [SerializeField] private AudioClip jumpSound;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Moving
        body.linearVelocity = new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y);

        // Flipping player when moving
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, 1);
        }

        // Jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                SoundManager.instance.PlaySound(jumpSound);
            }

            Jump();
        }

        // Set animator parameters
        anim.SetBool("go", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
        anim.SetTrigger("jump");
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }
}
