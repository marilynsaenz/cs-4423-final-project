using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Image slideImage;
    //[SerializeField] Color fadeColor = Color.black;
    [SerializeField] float slideTime = 1;
    [SerializeField] RectTransform slideRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        slideRectTransform = slideImage.rectTransform;
        slideRectTransform.anchoredPosition = new Vector2(Screen.width, 0);
        SlideOut();
    }

    public float GetSlideTime()
    {
        return slideTime;
    }

    public void SlideIn(string sceneName)
    {
        StartCoroutine(SlideInRoutine());
        IEnumerator SlideInRoutine()
        {
            float timer = 0;
            while (timer < slideTime)
            {
                slideRectTransform.anchoredPosition = Vector2.Lerp(new Vector2(Screen.width, 0), Vector2.zero, timer / slideTime);
                timer += Time.deltaTime;
                yield return null;
            }
            slideRectTransform.anchoredPosition = Vector2.zero;
            yield return null;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void SlideOut()
    {
        StartCoroutine(SlideOutRoutine());
        IEnumerator SlideOutRoutine()
        {
            float timer = 0;
            while (timer < slideTime)
            {
                slideRectTransform.anchoredPosition = Vector2.Lerp(Vector2.zero, new Vector2(Screen.width, 0), timer / slideTime);
                timer += Time.deltaTime;
                yield return null;
            }
            slideRectTransform.anchoredPosition = new Vector2(Screen.width, 0);
            yield return null;
        }
    }
}
