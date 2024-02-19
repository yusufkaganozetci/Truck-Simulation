using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckFollower : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (araba)
    public Vector3 offset; // Kameranýn hedefe olan mesafesi
    public float smoothSpeed = 0.125f; // Kameranýn yumuþak geçiþ hýzý

    private float rotationAngle; // Aracýn dönme açýsý


    public Transform lookAtTarget;
    void LateUpdate()
    {
        rotationAngle = target.eulerAngles.y;

        // Kameranýn gitmesi gereken pozisyonu ve rotasyonu hesapla
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
