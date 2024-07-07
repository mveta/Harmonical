using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform targetTransform; // Kameranýn gideceði hedef Transform
    public float transitionSpeed = 1f; // Kameranýn hareket ve rotasyon hýzý

    private bool moveToTarget = false;

    void Update()
    {
        if (moveToTarget)
        {
            // Pozisyonu yumuþak bir þekilde deðiþtirme
            transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * transitionSpeed);
            // Rotasyonu yumuþak bir þekilde deðiþtirme
            Quaternion targetQuaternion = Quaternion.Euler(targetTransform.rotation.eulerAngles);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, Time.deltaTime * transitionSpeed);

            // Hedef pozisyon ve rotasyona ulaþýldýðýnda hareketi durdur
            if (Vector3.Distance(transform.position, targetTransform.position) < 0.01f && Quaternion.Angle(transform.rotation, targetQuaternion) < 0.1f)
            {
                moveToTarget = false;
            }
        }
    }

    public void MoveToTarget()
    {
        moveToTarget = true;
    }
}
