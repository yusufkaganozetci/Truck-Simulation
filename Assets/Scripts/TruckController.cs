using System;
using TMPro;
using UnityEngine;

[Serializable]
public enum WheelType
{
    FrontRight,
    FrontLeft,
    BackRight,
    BackLeft,
}

[Serializable]
public class Wheel
{
    public WheelCollider wheelCollider;
    public Transform wheelMeshTransform;
    public WheelType wheelType;
}

public class WheelHelper
{
    public Wheel GetWheelByType(Wheel[] wheels, WheelType type)
    {
        Wheel wheel = null;
        for(int i=0;i<wheels.Length; i++) 
        {
            if (wheels[i].wheelType == type)
            {
                wheel = wheels[i];
                break;
            }
        }
        return wheel;
    }
}

public class TruckController : MonoBehaviour
{
    [SerializeField] Wheel[] wheels;
    [SerializeField] Transform steering;
    [SerializeField] float acceleration = 500;
    [SerializeField] float brakeForce = 300;
    [SerializeField] float maxTurnAngle = 15;
    [SerializeField] float maxSpeed = 130;
    [SerializeField] float maxSteeringWheelTurnAngle = 540;
    [SerializeField] float speedMultiplier = 5;

    private WheelHelper wheelHelper = new WheelHelper();
    private Rigidbody rb;
    private float currentAcceleration = 0;
    private float currentBrakeForce = 0;
    private float currentTurnAngle = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ManageInputs();
        Accelerate();
        Brake();
        Turn();
        UpdateWheelMeshes();
        UpdateSteering();
        SpeedMeter.Instance.ChangeSpeedMeter(GetCurrentVelocity());
    }

    private void UpdateSteering()
    {
        Vector3 steeringRot = steering.transform.rotation.eulerAngles;
        float rot = maxSteeringWheelTurnAngle * currentTurnAngle / maxTurnAngle;
        steering.transform.rotation = Quaternion.Euler(steeringRot.x
            , steeringRot.y, rot);
    }
    
    private void Turn()
    {
        wheelHelper.GetWheelByType(wheels, WheelType.FrontRight).
            wheelCollider.steerAngle = currentTurnAngle;
        wheelHelper.GetWheelByType(wheels, WheelType.FrontLeft).
            wheelCollider.steerAngle = currentTurnAngle;
    }

    private void Brake()
    {
        wheelHelper.GetWheelByType(wheels, WheelType.BackRight).
            wheelCollider.brakeTorque = currentBrakeForce;
        wheelHelper.GetWheelByType(wheels, WheelType.BackLeft).
            wheelCollider.brakeTorque = currentBrakeForce;
    }

    private void Accelerate()
    {
        if(GetCurrentVelocity() < maxSpeed)
        {
            wheelHelper.GetWheelByType(wheels, WheelType.BackRight).
            wheelCollider.motorTorque = currentAcceleration;
            wheelHelper.GetWheelByType(wheels, WheelType.BackLeft).
                wheelCollider.motorTorque = currentAcceleration;
        }
    }

    private float GetCurrentVelocity()
    {
        return rb.velocity.magnitude * speedMultiplier;
    }

    private void ManageInputs()
    {
        currentAcceleration = acceleration * GasPedal.Instance.accelerationDirection;//* Time.fixedDeltaTime;
        currentTurnAngle = maxTurnAngle * SimpleInput.GetAxis("Horizontal");
        if (BrakePedal.Instance.isPressing)
        {
            currentBrakeForce = brakeForce;
        }
        else
        {
            currentBrakeForce = 0;
        }
    }

    private void UpdateWheelMeshes()
    {
        Vector3 position;
        Quaternion rotation;
        for(int i=0;i<wheels.Length;i++)
        {
            wheels[i].wheelCollider.GetWorldPose(out position, out rotation);
            wheels[i].wheelMeshTransform.SetPositionAndRotation(position, rotation);
        }
    }

}