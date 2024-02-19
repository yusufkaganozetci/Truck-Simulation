using System;
using UnityEngine;

[Serializable]
public class CameraSystem
{
    public CameraType type;
    public Transform target;
    public Transform lookAtTarget;
    public Vector3 offset;
}

[Serializable]
public enum CameraType
{
    OUTSIDEOFTRUCK,
    INSIDEOFTRUCK,
    FRONTOFTRUCK,
    LEFTWHEEL,
    RIGHTWHEEL,
}

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject truckCamera;
    [SerializeField] CameraSystem[] cameraSystems;

    private int currentCameraSystemIndex = 0;

    private void Start()
    {
        TruckFollower.Instance.ChangeCamera(cameraSystems[currentCameraSystemIndex]);
    }

    public void ChangeCameraSystem()
    {
        currentCameraSystemIndex++;
        if (currentCameraSystemIndex >= cameraSystems.Length) currentCameraSystemIndex = 0;
        TruckFollower.Instance.ChangeCamera(cameraSystems[currentCameraSystemIndex]);
    }

}