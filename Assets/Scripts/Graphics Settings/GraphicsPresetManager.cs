using UnityEngine;
using System;
using TMPro;

/// <summary>
/// CHATGPT
/// </summary>

public class GraphicsPresetManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI graphicsPresetButtonText;

    public void ToggleGraphicsQuality()
    {
        // Получаем текущий индекс качества
        int currentQuality = QualitySettings.GetQualityLevel();
        
        // Определяем индексы пресетов "High Fidelity" и "Performant"
        int highFidelityIndex = Array.IndexOf(QualitySettings.names, "High Fidelity");
        int performantIndex = Array.IndexOf(QualitySettings.names, "Performant");

        // Переключаем между High Fidelity и Performant
        int nextQuality = (currentQuality == highFidelityIndex) ? performantIndex : highFidelityIndex;

        // Устанавливаем новое качество
        QualitySettings.SetQualityLevel(nextQuality, true);

        string qualityText = QualitySettings.names[nextQuality] == "High Fidelity" ? "Высокий" : "Низкий";
        graphicsPresetButtonText.text = $"Текущий пресет: {qualityText}";
        Debug.Log($"Качество графики переключено на: {QualitySettings.names[nextQuality]}");
    }
}
