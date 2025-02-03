using UnityEngine;
using TMPro;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI musicCreditsTextObject;

    void Start()
    {
        //проверка
        if (musicCreditsTextObject == null)
        {
            Debug.Log("Текстовый объект для отображения названия мелодии не прикреплен в инспекторе - Автор и Название мелодии не будут отображены в этой сцене");
            return;
        }

        //проигрывание аудио
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        UpdateCreditsText();
    }

    void UpdateCreditsText()
    {
        if (audioSource.clip != null && musicCreditsTextObject != null)
        {
            string trackName = audioSource.clip.name; //записывается название мелодии в переменную
            musicCreditsTextObject.text += " " + trackName; //название мелодии передается в текстовый объект
        }
        else if (musicCreditsTextObject != null)
        {
           musicCreditsTextObject.text = "Музыка в главном меню: Не выбрана";
           Debug.LogWarning("Музыкальный клип отсутствует.");
        }

    }
}
