using UnityEngine;
using TMPro; // разобраться с тмп

    /// <summary>
    /// CHATGPT
    /// </summary>

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5f; // Интервал обновления счетчика (в секундах)
    private float accum = 0; // Накопленное время
    private int frames = 0; // Количество кадров
    private float timeleft; // Оставшееся время для следующего обновления
    private float fps; // FPS

    public TextMeshProUGUI fpsText; // Текст для отображения FPS

    void Start()
    {
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        // Интервал закончился - обновляем FPS
        if (timeleft <= 0.0f)
        {
            fps = accum / frames;
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;

            //Обновляем текст
            if (fpsText != null)
            {
                fpsText.text = "FPS: " + Mathf.RoundToInt(fps).ToString();
            }
            else
            {
               Debug.Log("FPS: " + Mathf.RoundToInt(fps).ToString());
            }
        }
    }
}