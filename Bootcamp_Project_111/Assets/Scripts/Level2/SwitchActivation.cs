using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivation : MonoBehaviour
{
    [SerializeField]
    private MovingPlatform _movingPlatform;

    bool pressedY;

    private void Start()
    {
        pressedY = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartCoroutine(PlayCountdown());
        }
        if (pressedY && Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Moving platform activated");
            _movingPlatform.moveable = true;
        }
    }

    IEnumerator PlayCountdown()
    {
        pressedY = true;

        yield return new WaitForSeconds(4f);

        pressedY = false;
    }
}
