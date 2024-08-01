using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCase : MonoBehaviour
{
    [SerializeField] GameObject kcanvas;
    bool trig=false;
    [SerializeField] GameObject casedoorhandle,casedoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MoneyCase")){
            kcanvas.SetActive(true);
            trig = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MoneyCase"))
        {
            kcanvas.SetActive(false);
            trig = false;
        }
    }
    private void Update()
    {
        if (trig)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                casedoorhandle.transform.Rotate(5f, 0, 0);  
            }
            if (casedoorhandle.transform.localRotation.x ==1.0f)
            {
                Debug.Log("oldu");
               // casedoor.transform.Rotate(0, -90f, 0);
                casedoor.transform.SetPositionAndRotation(casedoor.transform.position, Quaternion.EulerRotation(0, -90, 0));
            }
            
        }
        
        
    }



}
