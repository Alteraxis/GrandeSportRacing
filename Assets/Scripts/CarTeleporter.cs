using UnityEngine;

public class CarTeleporter : MonoBehaviour
{
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform secondPoint;
    [SerializeField] private Transform thirdPoint;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (!firstPoint)
        {
            Debug.LogWarning("CarTeleporter: Пивот для телепорта на первую позицию не назначен.");
        }
        if (!secondPoint)
        {
            Debug.LogWarning("CarTeleporter: Пивот для телепорта на вторую позицию не назначен.");
        }
        if (!thirdPoint)
        {
            Debug.LogWarning("CarTeleporter: Пивот для телепорта на третью позицию не назначен.");
        }
    }

    /* ПЕРЕПИСАТЬ ПОД НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОИНТОВ */
    
    public void ToFirstPointTeleport()
    {
        // телепорт 1 поинт
        transform.position = firstPoint.position;
        transform.rotation = firstPoint.rotation; // сброс ротейшна

        // сброс велосити
        if (_rb)
        {
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }

    public void ToSecondPointTeleport()
    {
        // телепорт 2 поинт
        transform.position = secondPoint.position;
        transform.rotation = secondPoint.rotation; // сброс ротейшна

        // сброс велосити
        if (_rb)
        {
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }

    public void ToThirdPointTeleport()
    {
        // телепорт 3 поинт
        transform.position = thirdPoint.localPosition;
        transform.rotation = thirdPoint.localRotation; // сброс ротейшна

        // сброс велосити
        if (_rb)
        {
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }
}