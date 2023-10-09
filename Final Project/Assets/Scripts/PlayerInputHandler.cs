using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movement.Move(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.Move(new Vector3(1, 0, 0));
        }
        else
        {
            movement.Stop();
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }
    }
}
