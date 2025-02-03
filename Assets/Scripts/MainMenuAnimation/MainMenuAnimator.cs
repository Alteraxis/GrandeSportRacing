using UnityEngine;
using System.Collections;

    /// <summary>
    /// CHATGPT
    /// </summary>

public class MainMenuAnimator : MonoBehaviour
{
    public Transform startPosition; // Позиция начала движения камеры
    public float moveDuration = 1f; // Длительность движения камеры
    public float bounceHeight = 0.2f; // Высота баунса
    public float bounceDuration = 0.3f; // Длительность баунса
    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    private bool _isMoving = true;
    
    private void Awake()
    {
        //Назначение позиций
         _targetPosition = transform.position;
         transform.position = startPosition.position;
         _initialPosition = transform.position;
    }


    private void Start()
    {
        StartCoroutine(MoveAndBounce());
    }

    private IEnumerator MoveAndBounce()
    {
        // Движение вверх
        float timer = 0;
         while(timer < moveDuration)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(_initialPosition, _targetPosition, timer / moveDuration);
             yield return null;
        }
        // Баунс вверх-вниз
        timer = 0;
        Vector3 bounceTargetPosition = _targetPosition + Vector3.up * bounceHeight;
        while(timer < bounceDuration/2)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(_targetPosition, bounceTargetPosition, timer / (bounceDuration/2));
            yield return null;
        }
         timer = 0;
         while(timer < bounceDuration/2)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(bounceTargetPosition, _targetPosition, timer / (bounceDuration/2));
            yield return null;
        }

        _isMoving = false;
        
        // Запуск появления UI после завершения анимации камеры
        UIManager.Instance.EnableUI();
    }
    
    public bool IsMoving()
    {
        return _isMoving;
    }
}