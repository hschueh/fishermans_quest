using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed of the player movement

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0f) * speed;
        rb.velocity = movement;
    }
}
