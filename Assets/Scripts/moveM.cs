using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;

    public BananaManager bm;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move left and right
        float move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            move * speed,
            rb.linearVelocity.y
        );

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }
    }


     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("banana collect"))
        {
            Destroy(other.gameObject);
            bm.bananaCount++;
        }
    }
}