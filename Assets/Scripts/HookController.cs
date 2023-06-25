using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    private float damping = 10f; // A parameter for how much the chain should be affected by it's adjancency node's movement
    public float firespeed = 5f; // A parameter for how fast of the initial speed of the hook after firing
    public float idlePos = 1f; // A parameter for where is the idle position of the hook
    public float gravity = 9.8f; // A parameter for how much gravity should be applied to the hook
    public float speed = 5f; // Adjust the speed of the hook movement
    
    private Rigidbody2D rb;
    public Rigidbody2D prevRb;
    public Rigidbody2D charRb;

    private bool isFiring = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            isFiring = false;
        }

        float fireInput = Input.GetAxis("Fire");
        float hookInput = Input.GetAxis("Hook");
        float speedY = 0;
        if (isFiring)
        {
            speedY = rb.velocity.y - gravity * Time.deltaTime;
        }
        else
        {
            if (fireInput != 0f && rb.position.y < charRb.position.y)
            {
                isFiring = true;
                speedY = Mathf.Sqrt((ScreenBounds.screenTopBound - rb.position.y) * gravity * 2);
            }
            else if (hookInput != 0 && rb.position.y < charRb.position.y)
            {
                speedY = speed * hookInput;
            }
            else if (rb.position.y > charRb.position.y - idlePos)
            {
                speedY = rb.velocity.y - gravity * Time.deltaTime;
            }
            else
            {
                speedY = (charRb.position.y - idlePos - rb.position.y);
            }
        }
        rb.velocity = new Vector2((prevRb.position.x - rb.position.x) * damping, speedY);
    }
}
