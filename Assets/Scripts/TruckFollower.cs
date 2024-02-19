using UnityEngine;

public class TruckFollower : MonoBehaviour
{
    public Transform target;
    public Transform lookAtTarget;
    public Vector3 offset;

    private float rotationAngle;

    public static TruckFollower Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    void LateUpdate()
    {
        rotationAngle = target.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
        Vector3 desiredPosition = target.position - (rotation * offset);
        transform.position = desiredPosition;
        transform.LookAt(lookAtTarget);
    }

    public void ChangeCamera(CameraSystem cameraSystem)
    {
        target = cameraSystem.target;
        lookAtTarget = cameraSystem.lookAtTarget;
        offset = cameraSystem.offset;
    }

}