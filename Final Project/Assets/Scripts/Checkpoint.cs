using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.singleton.SetCheckpoint(transform.position);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}