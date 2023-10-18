using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;

    void LateUpdate()
    {
        float x = Mathf.Clamp(followTarget.position.x, xMin, xMax);
        float y = Mathf.Clamp(followTarget.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
