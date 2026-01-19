using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    [Header("Directional Sprites")]
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // blokada skosów
        if (movement.x != 0)
        {
            movement.y = 0;
        }

        movement = movement.normalized;

        UpdateDirectionSprite();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateDirectionSprite()
    {
        if (movement.y > 0)
        {
            spriteRenderer.sprite = spriteUp;
        }
        else if (movement.y < 0)
        {
            spriteRenderer.sprite = spriteDown;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.sprite = spriteLeft;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.sprite = spriteRight;
        }
    }
}
