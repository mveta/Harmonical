using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : MonoBehaviour
{
    [SerializeField]
    GameObject platformDrums;

    bool playable = false;
    GameManager gameManager;
    AudioSource audioSource;
    private void Start()
    {
        gameManager = GameManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(playable && Input.GetKeyDown(KeyCode.P) && gameManager.keyActive_p)
        {
            platformDrums.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(audioSource.clip);
        playable = true;

    }
    private void OnTriggerExit(Collider other)
    {
        playable = false;
    }
}
