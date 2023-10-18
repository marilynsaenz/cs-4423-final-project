using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Rigidbody2D rb;
    [SerializeField] float jumpForce = 10;
    [SerializeField] LayerMask groundMask;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 mvec)
    {
        mvec *= speed;
        mvec.y = rb.velocity.y;
        rb.velocity = mvec;
    }

    public void Stop()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

    }

    public void Jump()
    {
        if (Physics2D.OverlapCircleAll(transform.position-new Vector3(0, 0.5f, 0), 1, groundMask).Length == 0)
        {
            return;
        }
        if (rb.velocity.y > .1)
        {
            return;
        }
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
    }
}
