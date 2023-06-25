using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    private float damping = 10f; // A parameter for how much the chain should be affected by it's adjancency node's movement

    private Rigidbody2D rb;
    public Rigidbody2D prevRb;
    public Rigidbody2D nextRb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 speed = new Vector2(prevRb.position.x - rb.position.x, prevRb.position.y + nextRb.position.y - 2 * rb.position.y) * damping;
        rb.velocity = speed;
    }
}
