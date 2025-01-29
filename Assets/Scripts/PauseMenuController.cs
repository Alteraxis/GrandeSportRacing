using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    // Канвасы
    [SerializeField] private Canvas inGameHUDCanvas; // Ссылка на Canvas игрового интерфейса
    [SerializeField] private Canvas pauseMenuCanvas; // Ссылка на Canvas меню паузы

    // Список подменю
    [SerializeField] private GameObject carSelectMenu; // Подменю для выбора авто
    [SerializeField] private GameObject fastTravelMenu; // Подменю для быстрого перемещения
    [SerializeField] private GameObject sceneSelectMenu; // Подменю для выбора уровня

    // Ссылки
    [SerializeField] private CarSwitcher carSwitcher; // Ссылка на CarSwitcher
    [SerializeField] private CarTeleporter carTeleporter; // Ссылка на CarTeleporter
    [SerializeField] private SceneSwitcher sceneSwitcher; // Ссылка на SceneSwitcher

    private bool isPaused = false;

    void Start()
    {
        // Отключение меню паузы и подменю
        pauseMenuCanvas.gameObject.SetActive(false);
        inGameHUDCanvas.gameObject.SetActive(true);

        DeactivateAllSubMenus();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // публичные чтобы выставить в инспекторе, еще не разобрался как приватные назначить в методе onclick

    public void TogglePause()
    {
        isPaused = !isPaused; //меняем состояние IsPaused и тогглим паузу / выключаем паузу если нажать esc еще раз

        pauseMenuCanvas.gameObject.SetActive(isPaused);
        inGameHUDCanvas.gameObject.SetActive(!isPaused);

        Time.timeScale = isPaused ? 0f : 1f; //если IsPaused true - тогда время останавливается, если нет - возобновляется (тернарный оператор)

        if (!isPaused)
        {
            Debug.Log("Меню паузы закрыто");
            //запуск анимации закрытия меню в будущем
            DeactivateAllSubMenus();
        }
    }

    public void QuitGame()
    {
        Debug.Log("Выход из игры");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //исключительно в эдиторе для имитации закрытия игры
        #endif
    }

    private void DeactivateAllSubMenus()
    {
        carSelectMenu.SetActive(false);
        fastTravelMenu.SetActive(false);
        sceneSelectMenu.SetActive(false);
    }

    public void ShowCarSelectMenu()
    {
        DeactivateAllSubMenus();
        carSelectMenu.SetActive(true);
    }

    public void ShowFastTravelMenu()
    {
        DeactivateAllSubMenus();
        fastTravelMenu.SetActive(true);
    }

    public void ShowSceneSelectMenu()
    {
        DeactivateAllSubMenus();
        sceneSelectMenu.SetActive(true);
    }

    public void SwitchToCarSupraTurboA80()
    {
        carSwitcher.SwitchCar(carSwitcher.GetCar_SupraTurboA80(), carSwitcher.GetCar_GT3RS());
        Debug.Log("Автомобиль изменен на Toyota Supra Turbo A80");
    }

    public void SwitchToCarGT3RS()
    {
        carSwitcher.SwitchCar(carSwitcher.GetCar_GT3RS(), carSwitcher.GetCar_SupraTurboA80());
        Debug.Log("Автомобиль изменен на Porsche 911 GT3 RS 992");
    }

    public void ToFirstPointTeleport()
    {
        carTeleporter.ToFirstPointTeleport();
    }

    public void ToSecondPointTeleport()
    {
        carTeleporter.ToSecondPointTeleport();
    }

    public void ToThirdPointTeleport()
    {
        carTeleporter.ToThirdPointTeleport();
    }

    public void SwitchToCityScene()
    {
        if (sceneSwitcher != null)
        {
            sceneSwitcher.SwitchToScene(sceneSwitcher.citySceneName);
            Debug.Log("Переход в Городскую сцену");
            TogglePause();
        }
    }

    public void SwitchToMountainScene()
    {
        if (sceneSwitcher != null)
        {
            sceneSwitcher.SwitchToScene(sceneSwitcher.mountainSceneName);
            Debug.Log("Переход в сцену с Горным треком");
            TogglePause();
        }
    }
}

