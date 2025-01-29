using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("Сцены")]
    public string mountainSceneName;
    public string citySceneName;
    [SerializeField] private PauseMenuController pauseMenuController;

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadSceneIfNeeded(mountainSceneName);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadSceneIfNeeded(citySceneName);
        }
        */
    }

    public void LoadSceneIfNeeded(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName) && SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    // Метод для загрузки сцены по имени
    public void SwitchToScene(string sceneName)
    {
        Debug.Log("Попытка загрузить " + sceneName);
        
        SceneManager.LoadScene(sceneName);
    }
}
