using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    
    
    [SerializeField] float speed=5f;
    [SerializeField] GameObject player, playerboat;
    [SerializeField] GameObject fcanvas,uibuttoncanvas;
     int count = 0;
  
   
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            transform.Rotate(new Vector3(0,-5f,0)*speed*Time.deltaTime);
           
        } 
        if(Input.GetKey(KeyCode.I)) {
            transform.Rotate(new Vector3(0, 5f, 0) *speed* Time.deltaTime);
           
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            player.SetActive(false);
            playerboat.SetActive(true);
            fcanvas.SetActive(false);
        }
        if(playerboat.active == true)
        {
            transform.Translate(new Vector3(0, 0, -3f) * Time.deltaTime );
            uibuttoncanvas.SetActive(true);
        }
        else
        {
            uibuttoncanvas.SetActive(false);
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
    }

}//class
