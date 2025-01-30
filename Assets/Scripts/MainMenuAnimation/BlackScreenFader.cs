using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    /// <summary>
    /// CHATGPT
    /// </summary>

public class BlackScreenFader : MonoBehaviour
{
    //[SerializeField] private GameObject BlackScreen;
    public float fadeDuration = 1f; // Длительность исчезновения экрана
    private Image _blackScreen;

    private void Awake()
    {
        _blackScreen = GetComponent<Image>();
    }
    
    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            _blackScreen.color = new Color(_blackScreen.color.r, _blackScreen.color.g, _blackScreen.color.b, alpha);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}