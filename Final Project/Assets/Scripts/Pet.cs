using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pet : MonoBehaviour
{
    [SerializeField] Color fullColor = Color.white;
    [SerializeField] Color hungryColor = Color.red;
    [SerializeField] float hunger = 100f;
    [SerializeField] float hungerSpeedRate = 10.0f;
    [SerializeField] Transform player;
    [SerializeField] float someThreshold = 0.5f;
    [SerializeField] float moveSpeed = 3f;

    SpriteRenderer spriteRenderer;
    bool isDeathSequence = false;

    Player playerScript;
    Vector3 initialPosition;

    [SerializeField] AudioClip eatEnemy;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        hunger -= Time.deltaTime * hungerSpeedRate;

        float hungerLevel = Mathf.Clamp(hunger / 100f, 0f, 1f);

        Color currentColor = Color.Lerp(hungryColor, fullColor, hungerLevel);
        spriteRenderer.color = currentColor;

        if(hunger <= 0 && !isDeathSequence)
        {
            isDeathSequence = true;
            PetDeathSequence();
        }
    }

    public void FeedPet()
    {
        hunger = 100f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GetComponent<AudioSource>().clip = eatEnemy;
            GetComponent<AudioSource>().Play();
            FeedPet();
            Destroy(other.gameObject);
        }
        
    }

    void PetDeathSequence()
    {
        StartCoroutine(PetDeathSequenceRoutine());
        IEnumerator PetDeathSequenceRoutine()
        {
            // pause
            Time.timeScale = 0f;

            float lastTime = Time.realtimeSinceStartup;

            while(Vector2.Distance(transform.position, player.position) > someThreshold)
            {
                float currentTime = Time.realtimeSinceStartup;
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * (currentTime - lastTime));
                yield return null;
                lastTime = currentTime;
            }

            Time.timeScale = 1f;
            playerScript.LoseLife();
        }
    }

    public void ResetPet(Vector3 newPosition)
    {
        transform.parent.position = newPosition; 
        transform.localPosition = initialPosition;
        hunger = 100f;
        isDeathSequence = false;
        FeedPet();
    }
}
