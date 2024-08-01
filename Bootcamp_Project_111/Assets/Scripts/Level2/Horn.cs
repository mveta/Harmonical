using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : MonoBehaviour
{
    [SerializeField]
    GameObject platformDrums;

    bool playable = false;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
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
        //Horn sound in P, some indicator that player is in??
        playable = true;
        Debug.Log("inside");
    }
    private void OnTriggerExit(Collider other)
    {
        playable = false;
    }
}
