using UnityEngine;

public class CameraController : MonoBehaviour
{
    //сериализация
    [SerializeField] private GameObject cameraTarget;
    //приватные
    private GameObject player;
    //публичные
    public GameObject[] cameraPositions;
    public CarController controller;

    void Start()
    {
        Debug.Log("поиск объекта с тегом Player");
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Debug.Log("Найден объект с тегом Player. Имя: " + player.name);
            controller = player.GetComponent<CarController>();

            if (controller == null)
            {
                Debug.LogError("Не удалось присвоить controller компонент CarController");
            }
        }
        else
        {
            Debug.LogError("Объект с тегом Player не найден");
        }
    }

    
    void Update()
    {
        if (controller != null && controller.cameraTarget != null)
        {
            if (controller.cameraTarget.transform.childCount > 1)
            {
                gameObject.transform.position = controller.cameraTarget.transform.GetChild(0).transform.position;
                gameObject.transform.LookAt(controller.cameraTarget.transform.GetChild(1).transform.position);
            }
            else
            {
                Debug.LogError("У cameraTarget недостаточно дочерних объектов");
            }
        }
        else
        {
            Debug.LogError("controller или cameraTarget равен null");
        }
    }
}
