   using UnityEngine;
   using UnityEngine.SceneManagement;

    /// <summary>
    /// CHATGPT
    /// </summary>

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private string startSceneName = "CityTestTrack";
        [SerializeField] private GameObject blackScreen;
        public static UIManager Instance { get; private set; }
        public GameObject uiRoot; // MainMenu кнопки
        
        private void Awake()
        {
            blackScreen.SetActive(true);
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void EnableUI()
        {
            uiRoot.SetActive(true);
            Debug.Log("EnableUI() вызван");
        }

        public void StartGame()
        {
            SceneManager.LoadScene(startSceneName);
        }
        
        public void QuitGame()
        {
        Debug.Log("Выход из игры");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //исключительно в эдиторе для имитации закрытия игры
        #endif
        }
    }