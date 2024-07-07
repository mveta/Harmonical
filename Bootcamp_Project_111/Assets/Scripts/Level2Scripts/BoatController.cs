using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float laneDistance = 2f;
    public float laneChangeSpeed = 2f; // Þerit deðiþtirme hýzý
    private int currentLane = 1; // 0: Sol, 1: Orta, 2: Sað
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        // Sandalýn ileri hareketi
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Kullanýcý giriþlerini kontrol et
        if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
        {
            ChangeLane(-1);
        }
        if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            ChangeLane(1);
        }
        if (Input.GetKeyDown(KeyCode.S) && currentLane != 1)
        {
            ChangeLane(currentLane == 0 ? 1 : -1);
        }


        // Hedef pozisyona yumuþak geçiþ
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneChangeSpeed);
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
    }

    void ChangeLane(int direction)
    {
        currentLane += direction;
        targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Dam"))
        {
            RestartScene();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Final"))
        {
            CameraRotate cameraController = Camera.main.GetComponent<CameraRotate>();
            if (cameraController != null)
            {
                cameraController.MoveToTarget();
                StartCoroutine(stopSpeed());
            }
        }
    }
    IEnumerator stopSpeed()
    {
        forwardSpeed = 3f;
        yield return new WaitForSeconds(4.5f);
        forwardSpeed = 0f;
    }
    void RestartScene()
    {
        // Aktif sahnenin yeniden yüklenmesi
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
