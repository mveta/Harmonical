using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    GameManager gameManager;
    AudioSource audioSource;

    private void Start()
    {
        gameManager = GameManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameManager.jumpable = false;
            audioSource.PlayOneShot(audioSource.clip);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameManager.jumpable = true;
        }
    }

   

}
