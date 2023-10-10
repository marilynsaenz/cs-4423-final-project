using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>(), false);
            other.gameObject.layer = 0;  // Assuming 0 is your default layer for the player
        }
    }
}