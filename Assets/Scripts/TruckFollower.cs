using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckFollower : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (araba)
    public Vector3 offset; // Kameran�n hedefe olan mesafesi
    public float smoothSpeed = 0.125f; // Kameran�n yumu�ak ge�i� h�z�

    private float rotationAngle; // Arac�n d�nme a��s�


    public Transform lookAtTarget;
    void LateUpdate()
    {
        rotationAngle = target.eulerAngles.y;

        // Kameran�n gitmesi gereken pozisyonu ve rotasyonu hesapla
        Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
        Vector3 desiredPosition = target.position - (rotation * offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

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
