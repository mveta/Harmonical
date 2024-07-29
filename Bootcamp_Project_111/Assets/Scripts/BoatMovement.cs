using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    
    
    [SerializeField] float speed=5f;
    [SerializeField] GameObject player, playerboat;
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            transform.Rotate(new Vector3(0,-5f,0)*speed*Time.deltaTime);
           // playerboat.transform.Rotate(new Vector3(0, -5f, 0) * speed * Time.deltaTime);
        } 
        if(Input.GetKey(KeyCode.I)) {
            transform.Rotate(new Vector3(0, 5f, 0) *speed* Time.deltaTime);
           // playerboat.transform.Rotate(new Vector3(0, -5f, 0) * speed * Time.deltaTime);
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.SetActive(false);
            playerboat.SetActive(true);
        }
    }

}//class
