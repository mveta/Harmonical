using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivation : MonoBehaviour
{
    [SerializeField]
    private MovingPlatform _movingPlatform;

    bool pressedY;
    GameManager gameManager;
    AudioSource audioSource;

    private void Start()
    {
        gameManager = GameManager.Instance;
        pressedY = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && gameManager.keyActive_y)
        {
            StartCoroutine(PlayCountdown());
        }
        if (pressedY && Input.GetKeyDown(KeyCode.I))
        {
            _movingPlatform.moveable = true;
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    IEnumerator PlayCountdown()
    {
        pressedY = true;

        yield return new WaitForSeconds(4f);

        pressedY = false;
    }
}
