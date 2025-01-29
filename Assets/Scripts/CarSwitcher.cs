using UnityEngine;

public class CarSwitcher : MonoBehaviour
{
    [Header("Автомобили")]
    [SerializeField] private GameObject supra_turbo_a80;
    [SerializeField] private GameObject gt3rs_992;
    // Получение автомобиля
    public GameObject GetCar_SupraTurboA80() => supra_turbo_a80;
    public GameObject GetCar_GT3RS() => gt3rs_992;

    public void SwitchCar(GameObject carToActivate, GameObject carToDeactivate)
    {
        carToActivate.SetActive(true); // Активируем нужный объект
        carToDeactivate.SetActive(false); // Деактивируем другой объект
    }
}
