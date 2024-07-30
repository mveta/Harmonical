using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalPlayerDetect : MonoBehaviour
{

    [SerializeField] GameObject creditCanvas,animempty;
     [SerializeField]Animator anim;
    AnimatorStateInfo animStateInfo;

    private void Update()
    {
        animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(animStateInfo.normalizedTime > 1.0f)
        {
            SceneManager.LoadScene("mainmenu");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal")){
            creditCanvas.SetActive(true);
           
        }
    }



}
