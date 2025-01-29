using UnityEngine;

public class CarMainController : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    [SerializeField] private float brakeTorque = 400f; // значение тормозного момента
    public float torque = 470; //470 для gt3 rs
    public float steeringMaxAngle = 30; //около 30 градусов для gt3 rs

    private void FixedUpdate() {
        animateWheels();

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

        if (Input.GetAxis("Horizontal") != 0)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMaxAngle;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = 0;
            }
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
}

/*
if(Input.GetKey(KeyCode.W)){
            for (int i = 0; i < wheels.Length; i++){
                wheels[i].motorTorque = torque;
            }
        }else{
            for (int i = 0; i < wheels.Length; i++){
                wheels[i].motorTorque = 0;
            }
        } else if (Input.GetKey(KeyCode.S))
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = -brakeTorque; // Отрицательный момент
            }
        }
        // Движение без ускорения и торможения (без нажатых кнопок)
        else
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = 0;
            }
        }

        if(Input.GetAxis("Horizontal") != 0){
            for (int i = 0; i < wheels.Length -2; i++){
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMaxAngle;
            }
        }else{
            for (int i = 0; i < wheels.Length -2; i++){
                wheels[i].steerAngle = 0;
            }
        }
*/