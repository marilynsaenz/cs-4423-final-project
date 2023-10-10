using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            yield return new WaitForSecondsRealtime(2);

            // resume
            Time.timeScale = 1f;

            while(Vector2.Distance(transform.position, player.position) > someThreshold)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
