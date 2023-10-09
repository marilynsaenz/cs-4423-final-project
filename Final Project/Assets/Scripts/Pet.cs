using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] Color fullColor = Color.white;
    [SerializeField] Color hungryColor = Color.red;
    [SerializeField] float hunger = 100f;
    [SerializeField] float hungerSpeedRate = 10.0f;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hunger -= Time.deltaTime * hungerSpeedRate;

        float hungerLevel = Mathf.Clamp(hunger / 100f, 0f, 1f);

        Color currentColor = Color.Lerp(hungryColor, fullColor, hungerLevel);
        spriteRenderer.color = currentColor;
    }

    public void FeedPet()
    {
        hunger = 100f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            FeedPet();
            Destroy(other.gameObject);
        }
    }
}
