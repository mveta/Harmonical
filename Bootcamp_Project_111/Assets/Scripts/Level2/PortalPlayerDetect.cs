using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPlayerDetect : MonoBehaviour
{

    [SerializeField] GameObject creditCanvas,animempty;
     Animator anim;
    //[SerializeField] Animation creditsanim;
    [SerializeField] AnimationClip creditsanim;

    private void Awake()
    {
        anim = animempty.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal")){
            creditCanvas.SetActive(true);
            //if(anim.GetCurrentAnimatorStateInfo(0).IsName("credits") &&
            //    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            //{
            //    Debug.Log("bitti");
            //}
            
        }
    }



}
