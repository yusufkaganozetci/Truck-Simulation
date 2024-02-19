using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CameraSystem
{
    //public CameraType type;
    public Transform camTransform;
    public Transform target;
    public Transform lookAtTarget;
    public Vector3 offset;
}/*
[Serializable]
public enum CameraType
{
    INSIDEOFTRUCK,
    OUTSIDEOFTRUCK,
}*/

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject truckCamera;

    [SerializeField] CameraSystem[] cameraSystems;

    private int currentCameraSystemIndex = 0;

    private void Start()
    {
        truckCamera.transform.SetPositionAndRotation(cameraSystems[currentCameraSystemIndex].camTransform.position,
            cameraSystems[currentCameraSystemIndex].camTransform.rotation);
        FindObjectOfType<TruckFollower>().ChangeCamera(cameraSystems[currentCameraSystemIndex]);
    }

    

    public void ChangeCameraSystem()
    {
        currentCameraSystemIndex++;
        if (currentCameraSystemIndex >= cameraSystems.Length) currentCameraSystemIndex = 0;
        /*truckCamera.transform.SetPositionAndRotation(cameraSystems[currentCameraSystemIndex].camTransform.position,
            cameraSystems[currentCameraSystemIndex].camTransform.rotation);*/
        FindObjectOfType<TruckFollower>().ChangeCamera(cameraSystems[currentCameraSystemIndex]);
    }

}
