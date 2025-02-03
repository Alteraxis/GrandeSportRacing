using UnityEngine;

public class CarMainController : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    [SerializeField] private float brakeTorque = 1000f; // значение тормозного момента
    public float torque = 470; //470 для gt3 rs
    public float steeringMaxAngle = 30; //около 30 градусов для gt3 rs
    private Rigidbody rb;

    [Header("Настройки стабилизации")]
    [SerializeField] private float slipThreshold = 0.1f; // Порог бокового скольжения
    [SerializeField] private float stabilizationForce = 2f; // Множитель силы стабилизации
    
    [Header("Настройки рулевого управления")]
    [SerializeField] private float steeringSensitivity = 22.5f; // чувствительность руля
    private float currentSteerAngle; //текущий угол поворота колес 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSteerAngle = 0;
    }

    private void FixedUpdate() {
        animateWheels();
        ApplyStabilizingForce();

        // газ, тормоз/реверс
        if (Input.GetKey(KeyCode.W))
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = torque;
            }
        }
        else if (Input.GetKey(KeyCode.S)) // Имитация торможения двигателем
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = -brakeTorque;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = 0;
            }
        }

        // рулевое управление (система сглаженного поворота колес)
        float horizontalInput = Input.GetAxis("Horizontal");
        float targetSteerAngle = horizontalInput * steeringMaxAngle; //целевой угол поворота (на сколько изменить угол)

        currentSteerAngle = Mathf.Lerp(currentSteerAngle, targetSteerAngle, Time.deltaTime * steeringSensitivity); // сглаженный поворот колеса от текущего до максимального 
        for (int i = 0; i < wheels.Length - 2; i++)  //применение угла
         {
             wheels[i].steerAngle = currentSteerAngle;
         }
    }

    void animateWheels() {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels [i].GetWorldPose (out wheelPosition, out wheelRotation);
            wheelMesh [i].transform.position = wheelPosition;
            wheelMesh [i].transform.rotation = wheelRotation;
        }
    }

    private void ApplyStabilizingForce() //демо-версия
    {
        rb = GetComponent<Rigidbody>();
        Vector3 localVelocity = transform.InverseTransformDirection(rb.linearVelocity); //преобразование скорости объекта из глобальной в локальную

        if (Mathf.Abs(localVelocity.x) > slipThreshold)
        {
            rb.AddForce(-transform.right * localVelocity.x * stabilizationForce, ForceMode.Acceleration);
        }
    }
}