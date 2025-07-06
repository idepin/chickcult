using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public bool AllowMovement { get; set; } = true;

    void Update()
    {
        if (!AllowMovement)
        {
            rb.linearVelocity = Vector2.zero; // Stop movement if not allowed
            return;
        }
        // Ambil input dari keyboard (WASD atau panah)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // Biar nggak lebih cepat saat diagonal

        if (movement.x > 0)
        {
            spriteRenderer.flipX = true; // Menghadap kanan
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = false; // Menghadap kiri
        }
    }

    void LateUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
        // Pindahkan posisi dengan MovePosition
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
