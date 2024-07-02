using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class SwitchBehaviour : MonoBehaviour
{
    public GameObject mechanism;
    bool playable = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //play E
            playable = true;
            Debug.Log("Player entered the field");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playable = false;
            Debug.Log("Player exited the field");
        }
    }

    private void Update()
    {
        if (playable && Input.GetKeyDown(KeyCode.I) && mechanism.activeInHierarchy)
        {
            mechanism.GetComponent<Animator>().SetTrigger("activated");
             
        }
    }
}
