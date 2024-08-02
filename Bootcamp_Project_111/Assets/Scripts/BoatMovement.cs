using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{


    float rotatespeed = 3f;
    public float transspeed=5f;
    [SerializeField] GameObject player, boatCam, playerCam;
    [SerializeField] GameObject fcanvas,uibuttoncanvas;
     int count = 0;
    CharacterMovement CharacterMovement;
    [SerializeField] GameObject barrier,musiccasebarrier;
    bool onBoat = false;
    bool boatRowing = false;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CharacterMovement = new CharacterMovement();
    }
    public static BoatMovement Instance { get;  set; }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && onBoat)
        {
            if (boatRowing)
            {
                playerCam.SetActive(true);
                boatCam.SetActive(false);
                player.transform.SetParent(null);
                GameManager.Instance.jumpable = true;

                audioSource.Stop();
                boatRowing = false;

            }
            else
            {
                player.transform.SetParent(transform);
                playerCam.SetActive(false);
                boatCam.SetActive(true);
                GameManager.Instance.jumpable = false;
                audioSource.Play();
                boatRowing = true;
            }

        }
    }
    void FixedUpdate()
    {
        
        
        
        if(boatRowing == true)
        {
            transform.Translate(new Vector3(0, 0, -3f) *transspeed* Time.deltaTime );

            if (Input.GetKey(KeyCode.U))
            {
                transform.Rotate(new Vector3(0, -5f, 0) * rotatespeed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.O))
            {
                transform.Rotate(new Vector3(0, 5f, 0) * rotatespeed * Time.deltaTime);

            }
            uibuttoncanvas.SetActive(true);
        }
        else
        {
            uibuttoncanvas.SetActive(false);
        }
        if(barrier.GetComponent<BoxCollider>().enabled == false)
        {
            transspeed = 7f;
        }
        if (!musiccasebarrier.activeSelf)
        {
            transspeed = 7f;
        }

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            onBoat = true;
            count++;
            if (count == 1)
                StartCoroutine(CanvasActivation());
            

        }
        if (other.gameObject.CompareTag("Barrier"))
        {
            transspeed = 0;
        }
        if (other.gameObject.CompareTag("Guitar"))
        {
            
            transspeed = 10f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Trumpet"))
        {
            Destroy(other.gameObject);
            transspeed = 10f;
        }
    }
    
    IEnumerator CanvasActivation()
    {
        fcanvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        fcanvas.SetActive(false);
    }


}//class
