using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{


    float rotatespeed = 2f;
     public float transspeed=1.2f;
    [SerializeField] GameObject player, playerboat;
    [SerializeField] GameObject fcanvas,uibuttoncanvas;
     int count = 0;
    CharacterMovement CharacterMovement;

    private void Start()
    {
        CharacterMovement = new CharacterMovement();
    }
    public static BoatMovement Instance { get;  set; }
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            transform.Rotate(new Vector3(0,-5f,0)*rotatespeed*Time.deltaTime);
           
        } 
        if(Input.GetKey(KeyCode.I)) {
            transform.Rotate(new Vector3(0, 5f, 0) *rotatespeed* Time.deltaTime);
           
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            player.SetActive(false);
            playerboat.SetActive(true);
            fcanvas.SetActive(false);
        }
        if(playerboat.active == true)
        {
            transform.Translate(new Vector3(0, 0, -3f) *transspeed* Time.deltaTime );
            uibuttoncanvas.SetActive(true);
        }
        else
        {
            uibuttoncanvas.SetActive(false);
        }
        Debug.Log("boat : "+CharacterMovement.bootspeedglobal);
        if (CharacterMovement.bootspeedglobal)
        {           
            transspeed = 2f;
        }

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            if(count == 1)
            fcanvas.SetActive(true);
        }
        if (other.gameObject.CompareTag("Barrier"))
        {
            transspeed = 0;
           
        }
    }

}//class
