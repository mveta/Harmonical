using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetToBoat : MonoBehaviour
{
    bool pressedY;
    bool pressedU;
    bool pressedI;
    bool pressedO;
    bool pressedP;


    GameManager gameManager;

    [SerializeField] GameObject sphere;

    private void Start()
    {
        gameManager = GameManager.Instance;
        pressedY = false;
        pressedU = false;
        pressedI = false;
        pressedO = false;
        pressedP = false;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            pressedI = true;

            pressedY = false;
            pressedU = false;
            pressedO = false;
            pressedP = false;  
        }
        if (pressedI && Input.GetKeyDown(KeyCode.O) && gameManager.keyActive_o)
        {
            pressedO = true;

            pressedP = false;
            pressedU = false;
            pressedI = false;
            pressedY = false;
        }
        if(pressedO && Input.GetKeyDown(KeyCode.U) && gameManager.keyActive_u) 
        {
            pressedU = true;

            pressedP = false;
            pressedO = false;
            pressedI = false;
            pressedY = false;
        }
        if(pressedU && Input.GetKeyDown(KeyCode.Y) && gameManager.keyActive_y)
        {
            pressedY = true;

            pressedP = false;
            pressedU = false;
            pressedI = false;
            pressedU = false;
        }
        if(pressedY && Input.GetKeyDown(KeyCode.P) && gameManager.keyActive_p)
        {
            Debug.Log("Congrats");
            sphere.GetComponent<Collider>().enabled = false;   
            sphere.GetComponent<Animator>().enabled = true;
        }
    }

 
}
