using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    //[SerializeField] Transform followTarget;
    public GameObject followTarget;
    public Vector2 followOffset;
    private Vector2 threshold;
    public float speed = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        threshold = calculateThreshold();
        rb = followTarget.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
        Vector2 follow = followTarget.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if(Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }
        if(Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }
        float moveSpeed = Mathf.Abs(rb.velocity.x) > speed ? Mathf.Abs(rb.velocity.x) : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    private Vector2 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }
}
