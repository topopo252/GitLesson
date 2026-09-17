using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour //クラス名をPlayerMovementに変更すること
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
