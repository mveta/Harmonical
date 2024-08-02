using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{


    float rotatespeed = 2f;
    public float transspeed=2.2f;
    [SerializeField] GameObject player, playerboat;
    [SerializeField] GameObject fcanvas,uibuttoncanvas;
     int count = 0;
    CharacterMovement CharacterMovement;
    [SerializeField] GameObject barrier,musiccasebarrier;

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
        if(playerboat.activeSelf == true)
        {
            transform.Translate(new Vector3(0, 0, -3f) *transspeed* Time.deltaTime );
            uibuttoncanvas.SetActive(true);
        }
        else
        {
            uibuttoncanvas.SetActive(false);
        }
        if(barrier.GetComponent<BoxCollider>().enabled == false)
        {
            transspeed = 2.2f;
        }
        if (!musiccasebarrier.active)
        {
            transspeed = 2.2f;
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
        if (other.gameObject.CompareTag("Guitar"))
        {
            Destroy(other.gameObject);
            transspeed = 4f;
        }
        if (other.gameObject.CompareTag("Trumpet"))
        {
            Destroy(other.gameObject);
            transspeed = 4f;
        }
    }

}//class
