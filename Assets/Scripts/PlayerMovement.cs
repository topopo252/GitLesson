using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour //クラス名をPlayerMovementに変更すること
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 15f;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGrounded && Keyboard.current.wKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        float input = 0f;
        if (Keyboard.current.aKey.isPressed)
        {
            input -= 1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            input += 1f;
        }

        rb.linearVelocity = new Vector2(input * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}