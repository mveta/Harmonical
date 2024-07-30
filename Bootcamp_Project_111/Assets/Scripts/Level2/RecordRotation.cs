using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
 
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
        Debug.Log(other.gameObject + " entered");
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);  
    }
    

}
