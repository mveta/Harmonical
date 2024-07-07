using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamController : MonoBehaviour
{
    public Transform boat;
    public float minActivationDistance = 5f; // Minimum aktivasyon mesafesi
    public float maxActivationDistance = 10f; // Maksimum aktivasyon mesafesi
    public Collider activationArea; // Aktivasyon alaný
    public float moveDistance = 2f; // Barajýn hareket mesafesi
    public float moveSpeed = 2f; // Barajýn hareket hýzý
    public string direction = "left"; // Barajýn hareket yönü ("left" veya "right")
    private bool isMoved = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool moving = false;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = direction == "left" ? initialPosition + Vector3.left * moveDistance : initialPosition + Vector3.right * moveDistance;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, boat.position);

        // Sandalýn baraj alanýnda olup olmadýðýný kontrol et
        if (activationArea.bounds.Contains(boat.position))
        {
            if (direction == "left" && Input.GetKeyDown(KeyCode.K))
            {
                moving = true;
                SoundManager.Instance.SoundPlay(0);
            }
            else if(Input.GetKeyDown(KeyCode.L))
            {
                SoundManager.Instance.SoundPlayOneShot();
            }
            if (direction == "right" && Input.GetKeyDown(KeyCode.L) && !isMoved)
            {
                moving = true;
                SoundManager.Instance.SoundPlay(1);
            }
            else if(Input.GetKeyDown(KeyCode.K))
            {
                SoundManager.Instance.SoundPlayOneShot();
            }
        }

        // Barajý yumuþak þekilde hareket ettir
        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoved = true;
                moving = false;
                Debug.Log("Baraj hareket ettirildi!");
            }
        }
    }

}
