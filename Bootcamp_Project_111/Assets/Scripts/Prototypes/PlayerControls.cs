using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] KeyCode noteC;
    [SerializeField] KeyCode noteD;
    [SerializeField] KeyCode noteE;
    [SerializeField] KeyCode noteF;
    [SerializeField] KeyCode noteG;
    [SerializeField] KeyCode keyNote;
    void Update()
    {
        if (Input.GetKeyDown(noteC))
        {
            //C note plays
            Jump();
        }
        if (Input.GetKeyDown(noteD))
        {
            //D note plays
        }
        if (Input.GetKeyDown(noteE))
        {
            //E note plays
        }
        if (Input.GetKeyDown(noteF))
        {
            //F note plays
        }
        if (Input.GetKeyDown(noteG))
        {
            //G note plays
        }
    }

    void Jump()
    {
        //player rigidbody n stuff
        //if (isGrounded)
        //{
        //     leave sequence
        //}

    }
}
