using TMPro;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    [SerializeField] Transform speedIndicator;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] float maxSpeedMeterRotation;
    [SerializeField] float minSpeedMeterRotation;
    [SerializeField] float maxSpeed;

    private float currentRotationVelocity = 0.0f;

    public static SpeedMeter Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    public void ChangeSpeedMeter(float speed)
    {
        if(speed > maxSpeed) speed = maxSpeed;
        float wholeAreaAsDegree = Mathf.Abs(maxSpeedMeterRotation) + Mathf.Abs(minSpeedMeterRotation);
        float targetRotationAmount = maxSpeedMeterRotation - (speed * wholeAreaAsDegree / 130);
        float newRotationAmount = Mathf.SmoothDampAngle(speedIndicator.rotation.eulerAngles.z, targetRotationAmount, ref currentRotationVelocity, 0.1f);
        speedIndicator.rotation = Quaternion.Euler(0, 0, newRotationAmount);
    }

}